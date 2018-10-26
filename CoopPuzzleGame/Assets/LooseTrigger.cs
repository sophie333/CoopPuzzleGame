using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LooseTrigger : MonoBehaviour {

    [SerializeField]
    private Text textLose;

    [SerializeField]
    private Image image;

    private bool dead = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            dead = true;
        }
    }

    private void Update()
    {
        if (dead)
        {

            image.gameObject.SetActive(true);
            textLose.gameObject.SetActive(true);
        }
    }
}
