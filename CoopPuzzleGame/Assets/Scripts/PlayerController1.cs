using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float constantSpeed = 10.0f;
    public float turnSpeed = 1.0f;

    private Vector3 gravity; // gravity acceleration

    // Player variables
    private string m_tag;
    private Rigidbody m_rbody;
    private Transform m_transform;
    private Vector3 movement = Vector3.zero;
    private bool isFrozen = false;
    public Vector3 myNormal; // character normal

    void Start()
    {
        myNormal = transform.up; // normal starts as character up direction
        m_rbody = GetComponent<Rigidbody>();
        m_transform = transform;
        m_tag = gameObject.tag;

        if (m_tag == "player1")
        {
            gravity = new Vector3(0f, -9.8f, 0f);
        }
        else if (m_tag == "player2")
        {
            gravity = new Vector3(0f, -9.8f, 0f);
        }
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
        }
        else if (m_tag == "player2")
        {
            m_transform.Rotate(0, Input.GetAxis("Horizontal_P2") * turnSpeed * Time.deltaTime, 0);
            m_transform.Translate(0, 0, Input.GetAxis("Vertical_P2") * constantSpeed * Time.deltaTime);
        }
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
}
