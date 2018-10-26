using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed = 10.0f;
    
    private Vector3 gravity; // Local gravity vector

    // Player variables
    private string m_tag;
    private Rigidbody m_rbody;
    private Transform m_transform;
    private Vector3 movement = Vector3.zero;
    private bool isFrozen = false;

    void Start()
    {
        m_rbody = GetComponent<Rigidbody>();
        m_transform = transform;
        m_tag = gameObject.tag;

        if (m_tag == "player1")
        {
            gravity = new Vector3(0f, -9.8f, 0f);
        }
        else if (m_tag == "player2")
        {
            gravity = new Vector3(-9.8f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        if (!isFrozen)
        {
            m_rbody.AddForce(movement * constantSpeed + gravity);
        }
    }

    private void Update()
    {    
        if (m_tag == "player1") 
            {
            float speedV = 0;
            float speedH = 0;

            if (Input.GetAxisRaw("Vertical_P1") > 0.1f)
                speedV = 1;
            else if (Input.GetAxisRaw("Vertical_P1") < -0.1f)
                speedV = -1;
            else
                speedV = 0;

            if (Input.GetAxisRaw("Horizontal_P1") > 0.1f)
                speedH = 1;
            else if (Input.GetAxisRaw("Horizontal_P1") < -0.1f)
                speedH = -1;
            else
                speedH = 0;

            movement = m_transform.forward * speedV + m_transform.right * speedH;
        } 
        else if (m_tag == "player2")
        {
            float speedV = 0;
            float speedH = 0;

            if (Input.GetAxisRaw("Vertical_P2") > 0.1f)
                speedV = 1;
            else if (Input.GetAxisRaw("Vertical_P2") < -0.1f)
                speedV = -1;
            else
                speedV = 0;

            if (Input.GetAxisRaw("Horizontal_P2") > 0.1f)
                speedH = 1;
            else if (Input.GetAxisRaw("Horizontal_P2") < -0.1f)
                speedH = -1;
            else
                speedH = 0;

            movement = m_transform.forward * speedV + m_transform.right * speedH;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 5.0f, 200.0f, 30.0f), "Horizontal axis: ");
        GUI.Label(new Rect(150.0f, 5.0f, 200.0f, 30.0f), Input.GetAxis("Horizontal_P1").ToString());

        GUI.Label(new Rect(5.0f, 30.0f, 200.0f, 30.0f), "Vertical axis: ");
        GUI.Label(new Rect(150.0f, 30.0f, 200.0f, 30.0f), Input.GetAxis("Vertical_P1").ToString());
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
