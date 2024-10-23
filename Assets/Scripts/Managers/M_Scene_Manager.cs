using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Structs_Library;
using static ES_Enums_Library;

public class M_Scene_Manager : MonoBehaviour
{
    public M_C_CameraSwtich_Manager cameraSwtich_Manager;
    public M_B_DirectionPad_Manager directionPad_Manager;

    void Camera_Switch()
    {
        List<DirectionPad_Status> DirectionPad_Status_list = directionPad_Manager.DirectionPad_Return();

        foreach (DirectionPad_Status directionPad_Status in DirectionPad_Status_list)
        {
            switch (directionPad_Status.direction)
            {
                case Direction.front:
                    break;
                case Direction.back:
                    break;
                case Direction.left:
                    break;
                case Direction.right:
                    break;
                default:
                    breal;
            }

        }
    }

    private void Update()
    {

    }
}
