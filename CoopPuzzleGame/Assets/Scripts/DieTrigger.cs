using System.Collections;
using UnityEngine;

public class DieTrigger : MonoBehaviour {
    
    [SerializeField] AudioSource respawnSound;
    [SerializeField] AudioSource fallSound;

    private void Start()
    {
        respawnSound.volume = 0.4f;
        fallSound.volume = 0.8f;
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
            player.constantSpeed = 0;
            player.turnSpeed = 0;
            player.GetComponent<Rigidbody>().mass = 0.01f;
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.6f);
        GameManager.instance.Restart();
    }
}
