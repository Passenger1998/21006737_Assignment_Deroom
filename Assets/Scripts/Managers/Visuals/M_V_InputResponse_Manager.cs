using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_V_InputResponse_Manager : MonoBehaviour
{
    M_Scene_Manager Scene_Manager;
    public Slider slider;

    private void Awake()
    {
        Scene_Manager = FindObjectOfType<M_Scene_Manager>().gameObject.GetComponent<M_Scene_Manager>();
    }

    public struct Slider_Initialize_Data
    {
        public int value_max;

    }

    void Slider_Initialize(Slider_Initialize_Data data)
    {
        slider.maxValue = data.value_max;
    }

    public struct Slider_Sync_Data
    {
        public int value_current;
    }

    void Slider_Sync(Slider_Sync_Data data)
    {
        slider.value = data.value_current;
    }

    public struct VisualManager_Initialize_Data
    {
        public Slider_Initialize_Data slider_initialize_data;
    }

    public void VisualManager_Initialize(VisualManager_Initialize_Data data)

    {
        Slider_Initialize_Data slider_initialize_data = data.slider_initialize_data;
        Slider_Initialize(slider_initialize_data);
    }

    public struct VisualManager_Update_Data
    {
        public Slider_Sync_Data slider_sync_data;
    }
    public void VisualManager_Update(VisualManager_Update_Data data)
    {
        Debug.Log("worked");
        Slider_Sync_Data slider_sync_data = data.slider_sync_data;
        Slider_Sync(slider_sync_data);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
