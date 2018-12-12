using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{    
    [SerializeField] GameObject winText;
    [SerializeField] AudioSource goalSound;

    private int playerNr = 0;

    private void Start()
    {
        goalSound.volume = 0.3f;
    }

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
            winText.SetActive(true);
            goalSound.Play();
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.6f);
        GameManager.instance.NextLevel();
    }
}
