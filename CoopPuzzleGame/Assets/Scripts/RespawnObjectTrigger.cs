﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjectTrigger : MonoBehaviour
{
    [SerializeField]  private BoxBehavior box;
    [SerializeField] private GameObject pSystem;
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
        box.transform.position = box.GetOrigPos();
        pSystem.SetActive(false);
        pLight.intensity = 0;
        m_Material.color = Color.gray;
        audioUp.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        audioDown.Play();
    }
}
