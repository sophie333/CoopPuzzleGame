using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehavior : MonoBehaviour {

    [SerializeField]
    private Transform playerTrans;

    private Transform m_transform;

    private void Start()
    {
        m_transform = transform;
    }
    
    void Update ()
    {
        if (this.tag == "player1")
        {
            m_transform.position = new Vector3(playerTrans.position.x + 24.0f, playerTrans.position.y - 0.9f, playerTrans.position.z);
        }
        if (this.tag == "player2")
        {
            m_transform.position = new Vector3(playerTrans.position.x - 24.0f, playerTrans.position.y - 0.9f, playerTrans.position.z);
        }
	}
}
