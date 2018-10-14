using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeHandler : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if(player)
        {
            //player.SetGravity(0);
            //not y rotation
           // Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
           // player.transform.rotation = Quaternion.Euler(eulerRotation);
            //player.SetGravity(-120f);
        }
    }
}
