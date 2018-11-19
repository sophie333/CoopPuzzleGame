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
        StartCoroutine(ChangeLayer());
    }

    private void OnTriggerExit(Collider other)
    {
        move.Play("moveBack");
        StartCoroutine(ChangeLayer());
    }

    private IEnumerator ChangeLayer()
    {
        yield return new WaitForSeconds(0.5f);
        if (obj.layer == 9)
        {
            obj.layer = 10;
        } 
        else
        {
            obj.layer = 9;
        }
    }
}
