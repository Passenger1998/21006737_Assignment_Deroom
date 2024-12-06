using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C_CameraFollow_Manager : MonoBehaviour
{
    public GameObject target;
    public List<Camera> cameras;
    
    void CameraFollow_Hard()
    {
        foreach (Camera camera in cameras) 
        {
            if (camera.enabled)
            {
                camera.transform.position = new Vector3(target.transform.position.x, camera.transform.position.y, target.transform.position.z);
            }
        }

    }

    void CameraFollow_Soft()
    {
        foreach (Camera camera in cameras)
        {
            Vector3 velocity_ref = Vector3.zero;
            if (camera.enabled)
            {
                camera.transform.position = Vector3.SmoothDamp(camera.transform.position, new Vector3(target.transform.position.x, camera.transform.position.y, target.transform.position.z), ref velocity_ref, 0.05f);
            }
        }

    }

    public void CameraFollow_Manager_Update()
    {
        //CameraFollow_Hard();
        CameraFollow_Soft();
    }

}
