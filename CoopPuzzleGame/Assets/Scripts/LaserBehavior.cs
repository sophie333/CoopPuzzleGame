using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {
    
    [SerializeField] AudioSource laserHit;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player)
        {
            laserHit.Play();
            GameObject playerBody = player.transform.GetChild(0).gameObject;
            player.GetComponent<PlayerController1>().enabled = false;
            Vector3 startPosition = playerBody.transform.eulerAngles;
            Vector3 endPosition = new Vector3(playerBody.transform.eulerAngles.x - 90, playerBody.transform.eulerAngles.y, playerBody.transform.eulerAngles.z);
            playerBody.transform.eulerAngles = Vector3.Lerp(startPosition, endPosition, 5.0f);
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.Restart();
    }
}
