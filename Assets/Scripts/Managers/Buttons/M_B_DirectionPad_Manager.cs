using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static ES_Enums_Library;
using static T_M_001_001_All;
using static ES_Structs_Library;

public class M_B_DirectionPad_Manager : MonoBehaviour
{
    public List<IC_DP_Clicks_Locals> IC_DP_LeftClick_Locals_list;
    private bool isSelectedMax;

    private void SelectNumber_Check()
    {
        List<bool> bool_list = new List<bool>();
        foreach (IC_DP_Clicks_Locals locals in IC_DP_LeftClick_Locals_list)
        {
            bool_list.Add(locals.isSelected);
        }
        if (bool_list.Count(b => b) >= 2)
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

        foreach (IC_DP_Clicks_Locals locals in IC_DP_LeftClick_Locals_list)
        {
            result_list.Add(locals.DirectionPad_Status_Return());
        }

        return result_list;
    }

    private void Update()
    {
        SelectNumber_Check();
    }

}
