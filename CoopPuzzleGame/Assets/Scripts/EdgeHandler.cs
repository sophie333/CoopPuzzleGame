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
            Vector3 eulerRotation = new Vector3(m_transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            player.transform.rotation = Quaternion.Euler(eulerRotation);
            player.SetGravity(gravityVector);

            //send ray down
            RaycastHit hit;
            Ray ray = new Ray(m_transform.position, -m_transform.up);

            if (Physics.Raycast(ray, out hit))//jumpRange))
            {
                Debug.Log("Found face");
                JumpToWall(hit.point, hit.normal, player); // yes: jump to the wall
            }

            //enable movement
            //player.EnableMovement();

            //disable trigger

        }
    }

    private void JumpToWall(Vector3 point, Vector3 normal, PlayerController player)
    {
        //move to new face
        Vector3 originalPos = player.transform.position;
        Quaternion originalRot = player.transform.rotation;

        Vector3 destinPos = point + normal * (player.GetDistGround() + 0.5f); // will jump to 0.5 above wall
        Vector3 playerForward = Vector3.Cross(player.transform.right, normal);
        Quaternion destinRot = Quaternion.LookRotation(playerForward, normal);

        StartCoroutine(jumpTime(originalPos, originalRot, destinPos, destinRot, player));
        //jumptime
    }

    private IEnumerator jumpTime(Vector3 orgPos, Quaternion orgRot, Vector3 dstPos, Quaternion dstRot, PlayerController player)
    {
        for (float t = 0.0f; t < 1.0f;)
        {
            t += Time.deltaTime;
            player.transform.position = Vector3.Lerp(orgPos, dstPos, t);
            player.transform.rotation = Quaternion.Slerp(orgRot, dstRot, t);
            yield return null; // return here next frame
        }
    }
}
