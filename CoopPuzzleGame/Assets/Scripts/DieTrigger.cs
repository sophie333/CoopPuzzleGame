using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        BoxBehavior box = other.GetComponent<BoxBehavior>();

        if (box)
        {
            box.transform.position = box.GetOrigPos();
        }
    }
}
