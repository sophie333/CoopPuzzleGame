﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject pSystem;
    [SerializeField] private Animator move;
    //[SerializeField] private Animation moveBack;
    [SerializeField] private Light pLight;
    [SerializeField] private AudioSource audioUp;
    [SerializeField] private AudioSource audioDown;

    private Material m_Material;
    private Color m_Color;

    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        m_Color = m_Material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        move.Play("moveTo");
        pSystem.SetActive(false);
        pLight.intensity = 0;
        m_Material.color = Color.gray;
        audioUp.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        //move.Play("moveBack");
        //pSystem.SetActive(true);
        //pLight.intensity = 6.8f;
        //m_Material.color = m_Color;
        audioDown.Play();
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
