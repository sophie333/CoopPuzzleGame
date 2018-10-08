using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed;

    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 gravity = new Vector3(0, -120f, 0);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rbody.AddForce(movement * constantSpeed + gravity);
    }
}
