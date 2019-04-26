using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{
    public GameObject m_camera;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward, m_camera.transform.rotation * Vector3.up);
    }
}
