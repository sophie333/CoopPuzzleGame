using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisPlatformTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        obj.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(true);
    }
}
