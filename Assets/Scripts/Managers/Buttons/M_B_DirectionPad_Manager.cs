using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static ES_Enums_Library;
using static T_M_test;
using static ES_Structs_Library;
using UnityEngine.SceneManagement;

public class M_B_DirectionPad_Manager : MonoBehaviour
{

    M_Scene_Manager scene_Manager;

    public List<IC_DP_DirectionPadButtons_Locals> IC_DP_LeftClick_Locals_list;
    private bool isSelectedMax;


    private void Awake()
    {
        scene_Manager = FindObjectOfType<M_Scene_Manager>().gameObject.GetComponent<M_Scene_Manager>();
    }
    private void SelectNumber_Check()
    {
        List<bool> bool_list = new List<bool>();
        foreach (IC_DP_DirectionPadButtons_Locals locals in IC_DP_LeftClick_Locals_list)
        {
            bool_list.Add(locals.isClicked);
        }
        if (bool_list.Count(b => b) >= 4)
        {
            isSelectedMax = true;
        }
        else
        {
            isSelectedMax = false;
        }
    }

    public bool IsSelectedMax()
    {
        return isSelectedMax;
    }

    public List<DirectionPad_Status> DirectionPad_Return()
    {
        List<DirectionPad_Status> result_list = new List<DirectionPad_Status>();

        foreach (IC_DP_DirectionPadButtons_Locals locals in IC_DP_LeftClick_Locals_list)
        {
            result_list.Add(locals.DirectionPad_Status_Return());
        }

        return result_list;
    }

    public void DirectionPad_Manager_Update()
    {
        SelectNumber_Check();
        scene_Manager.Camera_Switch();
    }

}
