using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static ES_Enums_Library;
using static T_M_test;
using static ES_Structs_Library;
using UnityEngine.SceneManagement;

public class M_B_DisplaySwitch_Manager : MonoBehaviour
{

    M_Scene_Manager scene_Manager;

    public List<IC_DS_DisplaySwitch_Locals> IC_DS_ScreenSwitch_Locals_list;



    private void Awake()
    {
        scene_Manager = FindObjectOfType<M_Scene_Manager>().gameObject.GetComponent<M_Scene_Manager>();
    }

    public List<IC_DS_DisplaySwitch_Locals> IC_DS_ScreenSwitch_Locals_list_Return()
    {
        return IC_DS_ScreenSwitch_Locals_list;
    }

    public List<DirectionPad_Status> DirectionPad_Return()
    {
        List<DirectionPad_Status> result_list = new List<DirectionPad_Status>();

        foreach (IC_DS_DisplaySwitch_Locals locals in IC_DS_ScreenSwitch_Locals_list)
        {
            result_list.Add(locals.DirectionPad_Status_Return());
        }

        return result_list;
    }
}
