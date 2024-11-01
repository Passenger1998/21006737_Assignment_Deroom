using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_C_RaycastDetect_Actions : MonoBehaviour
{
    public struct RayCast_Detect_Data
    {
        public GameObject selectFrame_Object;
        public Camera camera;
    }


    public void RayCast_Detect(RayCast_Detect_Data data)
    {
        GameObject selectFrame_Object = data.selectFrame_Object;
        Camera camera = data.camera;

        Ray ray = Camera.main.ScreenPointToRay(RectTransformUtility.WorldToScreenPoint(camera, selectFrame_Object.transform.position));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject selectedObject = hit.transform.gameObject;
            Debug.Log("Selected Object: " + selectedObject.name);
            // Example action: Change color to red
            selectedObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
