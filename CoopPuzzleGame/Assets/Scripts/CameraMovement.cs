using UnityEngine;

public class CameraMovement : MonoBehaviour
{/*
    [SerializeField]
    private PlayerController m_player;
    private float m_playerAngle;

    private Transform m_transform;

    private void Start()
    {
        m_playerAngle = m_player.transform.rotation.eulerAngles.x;
    }
    
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

    [SerializeField] private Transform m_playerTrans;
    private Transform m_transform;
    private float m_angleX;
    private float m_angleY;
    private float m_distance;
    private float height;
    public float xRot = 30;
    public float yRot = 0;
    public float zRot = 0;

    private void Start()
    {
        m_transform = transform;
        m_angleX = m_transform.rotation.eulerAngles.x;
        m_angleY = m_transform.rotation.eulerAngles.y;
        m_distance = 100;
        height = 63.0f;
    }
    
    //void LateUpdate()
    //{
    //    //we get the rotation angle of the player
    //    float angleY = m_playerTrans.rotation.eulerAngles.y;
    //    float angleX = m_playerTrans.rotation.eulerAngles.x;

    //    //we rotate the camera with the same angle
    //    m_transform.rotation = Quaternion.Euler(new Vector3(m_angleX, angleY, 0.0f));
    //   // m_transform.rotation *= Quaternion.Euler(new Vector3(angleX, m_angleY, 0.0f));

    //    //we calculate the cartesian coordinates using the polar coordinates
    //    Vector3 offsetPosition = new Vector3(-m_distance * Mathf.Sin(angleY * Mathf.Deg2Rad), height, -m_distance * Mathf.Cos(angleY * Mathf.Deg2Rad));

    //    //we use the player position plus the offset calculated above
    //    m_transform.position = m_playerTrans.position + offsetPosition;
    //}

    void LateUpdate()
    {
     
        m_transform.position = m_playerTrans.position;
        
        //Vector3 wantedPosition = m_transform.localPosition + (m_playerTrans.up * height + m_playerTrans.forward * -m_distance);
        //m_transform.localPosition = Vector3.Slerp(m_transform.localPosition, wantedPosition, 0.9f);

        m_transform.localPosition += m_playerTrans.up * height + m_playerTrans.forward * -m_distance;

        m_transform.rotation = Quaternion.Slerp(m_transform.rotation, m_playerTrans.rotation, 0.7f);
        //m_cam.LookAt(m_playerTrans);
        //m_cam.eulerAngles += new Vector3(30.0f, 0.0f, 0.0f);
        //m_transform.LookAt(m_playerTrans);
        //m_transform.eulerAngles += new Vector3(xRot, yRot, zRot);
        //Vector3 rotVect = m_transform.localRotation.eulerAngles;

        //Quaternion rot = Quaternion.Euler(rotVect.x, rotVect.y, rotVect.z);
        //m_transform.localRotation = rot;
    }
}
