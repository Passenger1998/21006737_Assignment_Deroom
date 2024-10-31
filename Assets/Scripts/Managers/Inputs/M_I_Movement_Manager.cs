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


    public void MovementControl_OldInput_Keys()
    {
        InputMethod inputMethod = S_Game_Centre.game_Centre.InputDetails_Return().inputMethod;

        float speed = S_Game_Centre.game_Centre.MovementControls_Return().speed;

        Rigidbody rb = scene_Manager.Rigidbody_Return();

        if (inputMethod == InputMethod.oldinput)
        {

            Vector3 movement;
            if (Input.GetKey(KeyCode.W))
            {
                movement = Vector3.forward;
                rb.velocity = movement * speed * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.S))
            {
                movement = Vector3.back;
                rb.velocity = movement * speed * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.A))
            {
                movement = Vector3.left;
                rb.velocity = movement * speed * Time.deltaTime;
            } else if (Input.GetKey(KeyCode.D))
            {
                movement = Vector3.right;
                rb.velocity = movement * speed * Time.deltaTime;
            }
        }
    }



    public void Movement_Manager_Update()
    {
        MovementControl_OldInput_Keys();
    }
}

