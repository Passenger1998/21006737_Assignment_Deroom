using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Enums_Library;
using static ES_Structs_Library;
using static M_Scene_Manager;
using System.Linq;

public class M_I_Movement_Manager : MonoBehaviour
{
    M_Scene_Manager scene_Manager;

    private void Awake()
    {
        scene_Manager = FindObjectOfType<M_Scene_Manager>().gameObject.GetComponent<M_Scene_Manager>();
    }


    public void MovementControl_FullMouse()
    {
        InputMethod inputMethod = S_Game_Centre.game_Centre.InputDetails_Return().inputMethod;
        List<DirectionPad_Status> directionPad_Status_list_input = scene_Manager.managerList.userInterface.directionPad_Manager.DirectionPad_Return();
        List<DirectionPad_Status> directionPad_Status_list_display = scene_Manager.managerList.userInterface.displaySwitch_Manager.DirectionPad_Return();

        GameObject player = scene_Manager.managerList.inputControl.player;

        float speed = S_Game_Centre.game_Centre.MovementControls_Return().speed;

        

        if (inputMethod == InputMethod.fullmouse)
        {
            
            foreach (DirectionPad_Status directionPad_Status in directionPad_Status_list_input)
            {
                
                switch (directionPad_Status.direction)
                {
                    case Direction.front:
                        if (directionPad_Status.isClicked
                            && !directionPad_Status_list_display.FirstOrDefault(s => s.direction == Direction.front).isClicked)
                        {
                            Debug.Log("working");
                            player.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
                        }
                        break;
                    case Direction.back:
                        if (directionPad_Status.isClicked
                            && !directionPad_Status_list_display.FirstOrDefault(s => s.direction == Direction.back).isClicked)
                        {
                            player.transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
                        }
                        break;
                    case Direction.left:
                        if (directionPad_Status.isClicked
                            && !directionPad_Status_list_display.FirstOrDefault(s => s.direction == Direction.left).isClicked)
                        {
                            player.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                        }
                        break;
                    case Direction.right:
                        if (directionPad_Status.isClicked
                            && !directionPad_Status_list_display.FirstOrDefault(s => s.direction == Direction.right).isClicked)
                        {
                            player.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }



    public void Movement_Manager_Update()
    {
        MovementControl_FullMouse();
    }
}

