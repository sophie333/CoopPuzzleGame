using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatform : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Animator move;
    //[SerializeField] private Animation moveBack;

    private void OnTriggerEnter(Collider other)
    {
        move.Play("moveTo");
    }

    private void OnTriggerExit(Collider other)
    {
        move.Play("moveBack");
    }
}
