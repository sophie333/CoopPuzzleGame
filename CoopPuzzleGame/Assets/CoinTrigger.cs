using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour {

    [SerializeField]
    private Door2Movement door;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            door.key = true;
            Destroy(this.gameObject);
        }
    }
}
