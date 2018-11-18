using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTowerBehavior : MonoBehaviour
{
    private Transform m_transform;

    private void Start()
    {
        m_transform = transform;
    }

    private void OnTriggerStay(Collider other)
    {
        PowerSourceBehavior powerS = other.GetComponent<PowerSourceBehavior>();

        if (powerS)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                powerS.SetHasPSource(false);
                powerS.SetInGoal(true);
                powerS.transform.position = m_transform.GetChild(0).position;
            }
        }
    }
}
