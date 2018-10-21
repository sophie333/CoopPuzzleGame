using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHandler : MonoBehaviour
{
    public Vector3 m_gravityVector;
    private Transform m_transform;

    private Transform m_playerTrans;

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
            player.DisableMovement();
            m_playerTrans = player.transform;
            //Old player rotation
            //Vector3 eulerRotation = new Vector3(m_transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            //player.transform.rotation = Quaternion.Euler(eulerRotation);

            //send ray down
            RaycastHit hit;
            Ray ray = new Ray(m_transform.position, -m_transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                WalkAroundEdge(hit.point, hit.normal, player); 
            }

            player.SetGravity(m_gravityVector);
            player.EnableMovement();

            //TODO? disable trigger
        }
    }

    private void WalkAroundEdge(Vector3 point, Vector3 normal, PlayerController player)
    {
        //store original position & rotation
        Vector3 originalPos = m_playerTrans.position;
        Quaternion originalRot = m_playerTrans.rotation;

        /* OLD
        //calculate target position and rotation
        Vector3 targetPos = m_playerTrans.position + normal; //* player.GetDistGround(); //move player above target surface
        Vector3 playerForward = Vector3.Cross(m_playerTrans.right, normal); //calculate new player forward vector
        targetPos += playerForward * 1.5f; //move player forward to actually be over target surface
        Quaternion targetRot = Quaternion.LookRotation(playerForward, normal); //creating new rotation out of forward and up vector
        */
        
        //calculate target position and rotation
        Vector3 targetPos = (m_playerTrans.position + normal) + m_playerTrans.up * -1.5f; // move player above and little bit inside surface
        Vector3 playerForward = Vector3.zero;

        string movDirection = player.GetActiveAxis();

        if (movDirection == "forward")
        {
            playerForward = -m_playerTrans.up;
        }
        else if (movDirection == "backwards")
        {
            playerForward = m_playerTrans.up;
        }
        else if (movDirection == "sideways")
        {
            playerForward = m_playerTrans.forward;
        }
        
        Quaternion targetRot = Quaternion.LookRotation(playerForward, normal); //creating new rotation out of forward and up vector

        for (float t = 0.0f; t < 1.0f;)
        {
            t += Time.deltaTime;
            m_playerTrans.position = Vector3.Lerp(originalPos, targetPos, t);
            m_playerTrans.rotation = Quaternion.Slerp(originalRot, targetRot, t);
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
