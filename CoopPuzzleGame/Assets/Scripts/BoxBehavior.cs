using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour {

    private Vector3 m_position;

	void Start () {
        m_position = transform.position;
	}
	
	public Vector3 GetOrigPos()
    {
        return m_position;
    }
}
