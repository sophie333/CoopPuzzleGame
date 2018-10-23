using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed = 10.0f;
    
    private Vector3 gravity; // Local gravity vector

    // Player variables
    private Rigidbody m_rbody;
    private Transform m_transform;
    private Vector3 movement = Vector3.zero;
    private bool isFrozen = false;

    void Start()
    {
        m_rbody = GetComponent<Rigidbody>();
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
}
