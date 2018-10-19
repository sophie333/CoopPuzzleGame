using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHandler : MonoBehaviour
{
    public Vector3 gravityVector;
    private Transform m_transform;


   // private float jumpRange = 10; // range to detect target wall

    // Use this for initialization
    private void Start()
    {
        m_transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        
        if(player)
        {
            //disable movement
            player.DisableMovement();

            //rotate player
            //Vector3 eulerRotation = new Vector3(m_transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            //player.transform.rotation = Quaternion.Euler(eulerRotation);

            //send ray down
            RaycastHit hit;
            Ray ray = new Ray(m_transform.position, -m_transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                WalkAroundEdge(hit.point, hit.normal, player); 
            }

            //enable movement
            //player.EnableMovement();

            player.SetGravity(gravityVector);
            //disable trigger
            player.EnableMovement();

        }
    }

    private void WalkAroundEdge(Vector3 point, Vector3 normal, PlayerController player)
    {
        //store original position & rotation
        Vector3 originalPos = player.transform.position;
        Quaternion originalRot = player.transform.rotation;

        //calculate target position and rotation
        Vector3 targetPos = player.transform.position + normal * player.GetDistGround(); //move player above target surface
        Vector3 playerForward = Vector3.Cross(player.transform.right, normal); //calculate new player forward vector
        targetPos += playerForward * 1.5f; //move player forward to actually be over target surface
        Quaternion targetRot = Quaternion.LookRotation(playerForward, normal); //creating new rotation out of forward and up vector

        for (float t = 0.0f; t < 1.0f;)
        {
            t += Time.deltaTime;
            player.transform.position = Vector3.Lerp(originalPos, targetPos, t);
            player.transform.rotation = Quaternion.Slerp(originalRot, targetRot, t);
        }
        //StartCoroutine(jumpTime(originalPos, originalRot, targetPos, targetRot, player));
    }
    /*
    private IEnumerator jumpTime(Vector3 originalPos, Quaternion originalRot, Vector3 targetPos, Quaternion targetRot, PlayerController player)
    {
        for (float t = 0.0f; t < 1.0f;)
        {
            t += Time.deltaTime;
            player.transform.position = Vector3.Lerp(originalPos, targetPos, t);
            player.transform.rotation = Quaternion.Slerp(originalRot, targetRot, t);
            yield return null; // return here next frame
        }
    }*/
}
