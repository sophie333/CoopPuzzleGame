using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour {

    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource respawnSound;
    [SerializeField] AudioSource fallSound;

    private void Awake()
    {
        respawnSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        BoxBehavior box = other.GetComponent<BoxBehavior>();
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (box)
        {
            box.transform.position = box.GetOrigPos();
            Debug.Log("box here");
        }
        else if (player)
        {
            fallSound.Play();
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);
        gameManager.Restart();
    }
}
