using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject winText;
    [SerializeField] AudioSource cheering;

    private int playerNr = 0;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player)
        {
            playerNr++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player)
        {
            playerNr--;
        }
    }

    private void Update()
    {
        if (playerNr == 2)
        {
            door1.SetActive(false);
            door2.SetActive(false);
            winText.SetActive(true);
            cheering.Play();
        }
    }
}
