using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHandler1 : MonoBehaviour
{
    public Vector3 m_gravityVector; // Different gravity vector for every side of the cube
    private Transform m_transform;
    private Vector3 surfaceNormal; // current surface normal

    private Transform m_playerTrans;
    private bool active = false;
    
    private void Start()
    {
        m_transform = transform;
        if (gameObject.name != "TriggerB")
        {
            active = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();
        
        if(player && active)
        {
            player.DisableMovement();
            m_playerTrans = player.transform;
            
            // Send ray down to get normal of surface
            RaycastHit hit;
            Ray ray = new Ray(m_transform.position, -m_transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                WalkAroundEdge(hit.point, hit.normal, player);
                surfaceNormal = hit.normal;
            } else
            {
                surfaceNormal = Vector3.up;
            }

            player.myNormal = Vector3.Lerp(player.myNormal, surfaceNormal, 10 * Time.deltaTime);

            Vector3 myForward = Vector3.Cross(m_playerTrans.right, player.myNormal);
            Quaternion targetRot = Quaternion.LookRotation(myForward, player.myNormal);
            m_playerTrans.rotation = Quaternion.Lerp(m_playerTrans.rotation, targetRot, 10 * Time.deltaTime);

            player.SetGravity(m_gravityVector);
            player.EnableMovement();
        }
        active = true;
    }

    // Turns player around to stand on new surface
    private void WalkAroundEdge(Vector3 point, Vector3 normal, PlayerController1 player)
    {
        // Store original position & rotation
        Vector3 originalPos = m_playerTrans.position;
        Quaternion originalRot = m_playerTrans.rotation;
        
        // Calculate target position and rotation
        Vector3 targetPos = (m_playerTrans.position + normal) + m_playerTrans.up * -1.5f; // Move player above and little bit inside surface

        Vector3 myForward = Vector3.Cross(m_playerTrans.right, normal);

        // Create new forward direction for player


        Quaternion targetRot = Quaternion.LookRotation(myForward, normal); // Create new rotation out of (new) forward and up vector

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
