using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed = 10.0f;
    
    private Vector3 gravity; //local gravity vector

    //player variables
    private Rigidbody m_rbody;
    private Transform m_transform;
    private BoxCollider m_collider;
    private Vector3 movement = Vector3.zero;
    private bool isFrozen = false;
    private bool forward = false;
    private bool backwards = false;
    private bool sideways = false;

    void Start()
    {
        m_rbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<BoxCollider>();
        m_transform = transform;

        gravity = new Vector3(0f, -9.8f, 0f);
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        movement = m_transform.forward * Input.GetAxis("Vertical")* constantSpeed + m_transform.right * Input.GetAxis("Horizontal")* constantSpeed;

        CheckMovement();
    }

    private void CheckMovement()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            forward = true;
            backwards = false;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            backwards = true;
            forward = false;
        }
        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            sideways = true;
            backwards = false;
            forward = false;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 5.0f, 200.0f, 30.0f), "Horizontal axis: ");
        GUI.Label(new Rect(150.0f, 5.0f, 200.0f, 30.0f), Input.GetAxis("Horizontal").ToString());

        GUI.Label(new Rect(5.0f, 30.0f, 200.0f, 30.0f), "Vertical axis: ");
        GUI.Label(new Rect(150.0f, 30.0f, 200.0f, 30.0f), Input.GetAxis("Vertical").ToString());
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

    public float GetDistGround()
    {
        return m_collider.size.y - m_collider.center.y; //distance from character position to ground
    }

    public string GetActiveAxis()
    {
        if (forward)
        {
            return "forward";
        }
        else if(sideways)
        {
            return "sideways";
        }
        else if(backwards)
        {
            return "backwards";
        }
        return "none";
    }
}
