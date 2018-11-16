using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSourceBehavior : MonoBehaviour {

    private Transform m_transform;
    private bool pickedUp;
    private PlayerController1 player1;

    private void Start()
    {
        m_transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player && Input.GetKey(KeyCode.I))
        {
            if (!pickedUp)
            {
                pickedUp = true;
                Debug.Log("true");
            }
            else
            {
                pickedUp = false;
                Debug.Log("false");
            }
        }
    }

    private void Update()
    {
        if (pickedUp)
        {
            m_transform.position = player1.transform.position;
        }
    }
}
