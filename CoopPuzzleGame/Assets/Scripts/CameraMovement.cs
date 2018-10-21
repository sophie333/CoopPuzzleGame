﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerController m_player;
    private float m_playerAngle;

    private Transform m_transform;

    private void Start()
    {
        m_playerAngle = m_player.transform.rotation.eulerAngles.x;
    }
    /*
    void LateUpdate()
    {

        //we get the rotation angle of the player
        float angleX = m_player.transform.rotation.eulerAngles.x;
        float angleZ = m_player.transform.rotation.eulerAngles.z;

        //we calculate the cartesian coordinates using the polar coordinates
        Vector3 offsetPosition = new Vector3(-m_distance * Mathf.Sin(angleX * Mathf.Deg2Rad), height, -m_distance * Mathf.Cos(angleZ * Mathf.Deg2Rad));

        //we use the player position plus the offset calculated above
        m_transform.position = m_player.transform.position + offsetPosition;
    }*/
}