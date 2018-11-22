using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatformTrigger : MonoBehaviour
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
        //move.Play("moveBack");
    }

    /*private IEnumerator ChangeLayer()
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
    }*/
}
