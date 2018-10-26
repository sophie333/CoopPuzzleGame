using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

    [SerializeField]
    private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            door.transform.position = new Vector3(16.1f, -5.81f, 7.27f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            door.transform.position = new Vector3(11.09f, -5.81f, 7.27f);
        }
    }
}
