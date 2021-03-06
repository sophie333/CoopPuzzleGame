﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float constantSpeed = 6.0f;
    public float turnSpeed = 70.0f;

    [SerializeField] private AudioSource walkSound;
    [SerializeField] private ParticleSystem pSystem;
    private Vector3 gravity; // gravity acceleration

    // Player variables
    private string m_tag;
    private Rigidbody m_rbody;
    private Transform m_transform;
    private Vector3 m_position;
    private Vector3 movement = Vector3.zero;
    private bool isFrozen = false;
    public Vector3 myNormal; // character normal


    void Start()
    {
        myNormal = transform.up; // normal starts as character up direction
        m_rbody = GetComponent<Rigidbody>();
        m_transform = transform;
        m_tag = gameObject.tag;
        m_position = transform.position;

        if (m_tag == "player1")
        {
            gravity = new Vector3(0f, -9.8f, 0f);
        }
        else if (m_tag == "player2")
        {
            gravity = new Vector3(0f, -9.8f, 0f);
        }
        pSystem.Stop();
    }

    void FixedUpdate()
    {
        if (!isFrozen)
        {
            //m_rbody.AddForce(movement * constantSpeed + gravity);
            m_rbody.AddForce(gravity + m_rbody.mass * myNormal);
        }
    }

    private void Update()
    {
        if (m_tag == "player1")
        {
            m_transform.Rotate(0, Input.GetAxis("Horizontal_P1") * turnSpeed * Time.deltaTime, 0);
            m_transform.Translate(0, 0, Input.GetAxis("Vertical_P1") * constantSpeed * Time.deltaTime);
            if (Input.GetAxis("Vertical_P1") != 0)
            {
                walkSound.mute = false;
            }
            else
            {
                walkSound.mute = true;
            }
        }
        else if (m_tag == "player2")
        {
            m_transform.Rotate(0, Input.GetAxis("Horizontal_P2") * turnSpeed * Time.deltaTime, 0);
            m_transform.Translate(0, 0, Input.GetAxis("Vertical_P2") * constantSpeed * Time.deltaTime);
            if (Input.GetAxis("Vertical_P2") != 0)
            {
                walkSound.mute = false;
            }
            else
            {
                walkSound.mute = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            pSystem.Play();
            StartCoroutine(Collision());
        }
    }

    IEnumerator Collision()
    {
        yield return new WaitForSeconds(0.05f);
        pSystem.Stop();
    }

    public void SetGravity(Vector3 _grav)
    {
        gravity = _grav;
    }

    public void DisableMovement()
    {
        m_rbody.isKinematic = true;
        isFrozen = true;
    }

    public void EnableMovement()
    {
        m_rbody.isKinematic = false;
        isFrozen = false;
    }

    public Vector3 GetOrigPos()
    {
        return m_position;
    }
}
