using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisObjectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject obj;
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
        audioUp.volume = 0.2f;
        audioDown.volume = 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        obj.SetActive(false);
        pSystem.SetActive(false);
        pLight.intensity = 0;
        m_Material.color = Color.gray;
        audioUp.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(true);
        pSystem.SetActive(true);
        pLight.intensity = 6.8f;
        m_Material.color = m_Color;
        audioDown.Play();
    }
}
