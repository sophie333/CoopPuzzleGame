using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour {

    [SerializeField]
    private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player)
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player)
        {
            door.SetActive(true);
        }
    }
}
