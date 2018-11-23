using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource laserHit;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player)
        {
            laserHit.Play();
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);
        gameManager.Restart();
    }
}
