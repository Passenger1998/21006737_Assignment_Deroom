using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class M_C_Raycast_Manager : MonoBehaviour
{

    public GameObject selectFrame_Object;
    public Camera camera;

    public struct RayCast_Detect_Data
    {
        public GameObject selectFrame_Object;
        public Camera camera;
    }


    public void RayCast_Detect(RayCast_Detect_Data data)
    {
        GameObject selectFrame_Object = data.selectFrame_Object;
        Camera camera = data.camera;

        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(camera, selectFrame_Object.transform.position);
        Ray ray = camera.ScreenPointToRay(new Vector3(screenPosition.x, screenPosition.y, 0));
        ray.direction = camera.transform.TransformDirection(ray.direction);
        Debug.Log(ray.direction.y);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10, UnityEngine.Color.red);
        if (Physics.Raycast(ray, out hit, 10))
        {
            GameObject selectedObject = hit.transform.gameObject;
            if (selectedObject != null)
            {
                //Debug.Log("Selected Object: " + selectedObject.name);
                
            }
            
        }
    }

    public void Raycast_Manager_Update()
    {
        RayCast_Detect_Data rayCast_Detect_Data = new RayCast_Detect_Data
        {
            selectFrame_Object = selectFrame_Object,
            camera = camera
        };
        RayCast_Detect(rayCast_Detect_Data);
    }
}
