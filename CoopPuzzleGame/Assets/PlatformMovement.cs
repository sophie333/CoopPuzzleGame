using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    [SerializeField]
    private GameObject platform;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            platform.transform.position = new Vector3(platform.transform.position.x, 9.45f, platform.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            platform.transform.position = new Vector3(platform.transform.position.x, 5.45f, platform.transform.position.z);
        }
    }
}
