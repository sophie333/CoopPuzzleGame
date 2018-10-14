using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed;

    //private Vector3 gravity = new Vector3(0, -120f, 0);
    private float gravity = -120f;
    private float lerpSpeed = 10; // smoothing speed
    private Vector3 surfaceNormal; //current surface normal

    //player variables
    private Vector3 playerNormal; // player normal
    private Rigidbody rbody;
    private Transform m_transform;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        m_transform = transform;
        playerNormal = transform.up;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rbody.AddForce(movement * constantSpeed); //+ gravity
        //apply constant weight force according to player normal
        rbody.AddForce(gravity * rbody.mass * playerNormal);
    }

    private void Update()
    {
        //update surface normal
        Ray ray = new Ray(m_transform.position, -playerNormal);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        { //use it to update surface normal
            Debug.Log("yej");
            surfaceNormal = hit.normal;
        }
        else
        {
            Debug.Log("nop");
            surfaceNormal = Vector3.up;
        }
        playerNormal = Vector3.Lerp(playerNormal, surfaceNormal, lerpSpeed * Time.deltaTime);
    }
    /* public void SetGravity(float y)
     {
         gravity = new Vector3(0, y, 0);
     }*/

    private void OnTriggerEnter(Collider other)
    {
        Ray ray = new Ray(m_transform.position, m_transform.for)
    }

        public void CrossEdge()
    {
        rbody.isKinematic = true;
        Vector3 originalPos = m_transform.position;
        Quaternion originalRot = m_transform.rotation;

    }
}
