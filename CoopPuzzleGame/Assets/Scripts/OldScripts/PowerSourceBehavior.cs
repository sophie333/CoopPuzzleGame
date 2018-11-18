using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSourceBehavior : MonoBehaviour {

    private Transform m_transform;
    private PlayerController1 player1;
    private bool hasPSource;
    private bool inGoal;

    private void Start()
    {
        m_transform = transform;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController1 player = other.GetComponent<PlayerController1>();

        if (player && !inGoal)
        {
            if(Input.GetKeyUp(KeyCode.I))
            {
                if (!hasPSource)
                {
                    player1 = player;
                    hasPSource = true;
                }
                else
                {
                    player1 = null;
                    hasPSource = false;
                }
            }
        }
    }

    private void Update()
    {   
        if (GetHasPSource())
        {
            m_transform.position = player1.transform.position + player1.transform.forward * 1.5f;
            m_transform.rotation = player1.transform.rotation;
        }
    }

    public bool GetHasPSource()
    {
        return hasPSource;
    }

    public void SetHasPSource(bool boolean)
    {
        hasPSource = boolean;
    }

    public bool GetInGoal()
    {
        return inGoal;
    }

    public void SetInGoal(bool boolean)
    {
        inGoal = boolean;
    }
}
