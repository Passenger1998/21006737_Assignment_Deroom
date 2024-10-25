using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Structs_Library;
using static ES_Enums_Library;
using System;

public class M_Scene_Manager : MonoBehaviour
{
    
    public ManagerList managerList;
    [Serializable]
    public class ManagerList
    {
        
        public UserInterface userInterface;
        [Serializable]
        public class UserInterface
        {
            public M_B_DirectionPad_Manager directionPad_Manager;
        }

        public CameraBehaviour cameraBehaviour;
        [Serializable]
        public class CameraBehaviour
        {
            public M_C_CameraSwtich_Manager cameraSwtich_Manager;
        }
        
    }

    
    

    public void Camera_Switch()
    {
        List<DirectionPad_Status> DirectionPad_Status_list = managerList.userInterface.directionPad_Manager.DirectionPad_Return();

        foreach (DirectionPad_Status directionPad_Status in DirectionPad_Status_list)
        {
            switch (directionPad_Status.direction)
            {
                case Direction.front:
                    if (directionPad_Status.isDisplayOn)
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_front.enabled = true;
                    }
                    else
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_front.enabled = false;
                    }
                    break;
                case Direction.back:
                    if (directionPad_Status.isDisplayOn)
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_back.enabled = true;
                    }
                    else
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_back.enabled = false;
                    }
                    break;
                case Direction.left:
                    if (directionPad_Status.isDisplayOn)
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_left.enabled = true;
                    }
                    else
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_left.enabled = false;
                    }
                    break;
                case Direction.right:
                    if (directionPad_Status.isDisplayOn)
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_right.enabled = true;
                    }
                    else
                    {
                        managerList.cameraBehaviour.cameraSwtich_Manager.camera_right.enabled = false;
                    }
                    break;
                default:
                    break;
            }

        }
    }

    private void Update()
    {
        managerList.userInterface.directionPad_Manager.DirectionPad_Manager_Update();
    }
}
