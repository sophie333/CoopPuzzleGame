﻿using UnityEngine;
using System.Collections;

namespace ISS
{
    public class MoveCharacter : MonoBehaviour
    {
        [SerializeField]
        private float m_speed = 5.0f;

        [SerializeField]
        private float m_rotSpeed = 50.0f;

        private Transform m_transform;

        // Use this for initialization
        void Start()
        {
            m_transform = transform;
        }

        // Update is called once per frame
        void Update()
        {
            float rotY = m_transform.rotation.eulerAngles.y;

            m_transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotY + m_rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0.0f));

            m_transform.position += m_transform.forward * m_speed * Input.GetAxis("Vertical") * Time.deltaTime;
        }
    }
}
