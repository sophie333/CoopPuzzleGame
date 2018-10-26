using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Movement : MonoBehaviour {

    [SerializeField]
    private GameObject door;

    public bool key = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player && key)
        {
            door.transform.position = new Vector3(door.transform.position.x, 14.88f, door.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            door.transform.position = new Vector3(door.transform.position.x, 11.14f, door.transform.position.z);
        }
    }
}
