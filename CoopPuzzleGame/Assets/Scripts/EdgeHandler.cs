using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHandler : MonoBehaviour
{
    public Vector3 m_gravityVector; // Different gravity vector for every side of the cube
    private Transform m_transform;

    private Transform m_playerTrans;
    
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
            
            // Send ray down to get normal of surface
            RaycastHit hit;
            Ray ray = new Ray(m_transform.position, -m_transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                WalkAroundEdge(hit.point, hit.normal, player); 
            }

            player.SetGravity(m_gravityVector);
            player.EnableMovement();
        }
    }

    // Turns player around to stand on new surface
    private void WalkAroundEdge(Vector3 point, Vector3 normal, PlayerController player)
    {
        // Store original position & rotation
        Vector3 originalPos = m_playerTrans.position;
        Quaternion originalRot = m_playerTrans.rotation;
        
        // Calculate target position and rotation
        Vector3 targetPos = (m_playerTrans.position + normal) + m_playerTrans.up * -1.5f; // Move player above and little bit inside surface
        Vector3 playerForward = Vector3.zero; 
        
        // Create new forward direction for player
        // When moving forward
        if (Vector3.Cross(m_playerTrans.right, normal) == -m_playerTrans.up)
        {
            playerForward = -m_playerTrans.up;
        }
        // When moving backwards
        else if (Vector3.Cross(-m_playerTrans.right, normal) == -m_playerTrans.up)
        {
            playerForward = m_playerTrans.up;
        }
        // When moving sideways
        else if (Vector3.Cross(m_playerTrans.forward, normal) == -m_playerTrans.up || Vector3.Cross(-m_playerTrans.forward, normal) == -m_playerTrans.up)
        {
            playerForward = m_playerTrans.forward;
        }
        
        Quaternion targetRot = Quaternion.LookRotation(playerForward, normal); // Create new rotation out of (new) forward and up vector

        // Move player on right position bit by bit
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
