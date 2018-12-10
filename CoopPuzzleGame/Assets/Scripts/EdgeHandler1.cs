using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHandler1 : MonoBehaviour
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
        PlayerController1 player = other.GetComponent<PlayerController1>();
        
        if(player)
        {
            player.DisableMovement();
            m_playerTrans = player.transform;
            
            // Send ray down to get normal of surface
            Ray ray = new Ray(m_transform.position, -m_transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                WalkAroundEdge(hit.point, hit.normal, player);
            } 

            // Set new gravity
            player.SetGravity(m_gravityVector);
            // Make player able to move again
            player.EnableMovement();
        }
    }

    // Turns player around to stand on new surface
    private void WalkAroundEdge(Vector3 point, Vector3 normal, PlayerController1 player)
    {
        // Store original position & rotation
        Vector3 originalPos = m_playerTrans.position;
        Quaternion originalRot = m_playerTrans.rotation;

        // Calculate target position and rotation
        // Move player above and little bit inside surface
        Vector3 targetPos = (m_playerTrans.position + normal) + m_playerTrans.up * -1.5f;// + m_playerTrans.forward * 1.1f; ;
        Vector3 playerForward = Vector3.Cross(m_playerTrans.right, normal);
        // Create new rotation out of (new) forward and up vector
        Quaternion targetRot = Quaternion.LookRotation(playerForward, normal); 
        StartCoroutine(SmoothRotate(originalPos, originalRot, targetPos, targetRot, player));
    }
    
    //Smooth transition between both positions
    private IEnumerator SmoothRotate(Vector3 originalPos, Quaternion originalRot, Vector3 targetPos, Quaternion targetRot, PlayerController1 player)
    {
        for (float t = 0.0f; t < 1.0f;)
        {
            t += Time.deltaTime;
            player.transform.position = Vector3.Lerp(originalPos, targetPos, t);
            player.transform.rotation = Quaternion.Slerp(originalRot, targetRot, t);
            yield return null; // return here next frame
        }
    }
}
