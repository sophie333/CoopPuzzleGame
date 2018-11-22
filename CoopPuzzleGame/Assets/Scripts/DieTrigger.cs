using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour {

    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        BoxBehavior box = other.GetComponent<BoxBehavior>();
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (box)
        {
            box.transform.position = box.GetOrigPos();
        }
        else if (player)
        {
            gameManager.Restart();
        }
    }
}
