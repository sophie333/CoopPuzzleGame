using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed = 10.0f;
    
    private Vector3 gravity; //local gravity vector
    private float distGround; //distance from character position to ground

    //player variables
    private Rigidbody m_rbody;
    private Transform m_transform;
    private BoxCollider m_collider;
    private Vector3 movement = Vector3.zero;
    private bool frozenMov;

    void Start()
    {
        m_rbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<BoxCollider>();
        m_transform = transform;
        gravity = new Vector3(0f, -9.8f, 0f);
        distGround = m_collider.size.y - m_collider.center.y;
    }

    void FixedUpdate()
    {
        if (!frozenMov)
        {
            m_rbody.AddForce(movement * constantSpeed + gravity);
        }
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    public void SetGravity(Vector3 _grav)
    {
        gravity = _grav;
    }

    public void DisableMovement()
    {
        m_rbody.isKinematic = true;
        frozenMov = true;
    }

    public void EnableMovement()
    {
        //frozenMov = false;
        m_rbody.isKinematic = false;
    }

    public float GetDistGround()
    {
        return distGround;
    }
}
