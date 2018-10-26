using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour {
    
    [SerializeField]
    private Text textWin;


    [SerializeField]
    private Image image;

    private int number = 0;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            number++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            number--;
        }
    }

    private void Update()
    {
        if (number == 2)
        {

            image.gameObject.SetActive(true);
            textWin.gameObject.SetActive(true);
        }
    }
}
