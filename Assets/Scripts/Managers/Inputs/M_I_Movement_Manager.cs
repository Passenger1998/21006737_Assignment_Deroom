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
        InputMethod inputMethod = S_Game_Centre.GameCentre.InputDetails_Return().inputMethod;
        GameObject player = scene_Manager.Player_Return();
        float speed = S_Game_Centre.GameCentre.MovementControls_Return().speed;

        Rigidbody rb = scene_Manager.Rigidbody_Return();

        if (inputMethod == InputMethod.oldinput)
        {

            Vector3 movement;
            if (Input.GetKey(KeyCode.W))
            {
                movement = player.transform.forward;
                rb.velocity = movement * speed;
            } else if (Input.GetKey(KeyCode.S))
            {
                movement = - player.transform.forward;
                rb.velocity = movement * speed;
            } else if (Input.GetKey(KeyCode.A))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -90f, 0));
                rb.rotation = Quaternion.Slerp(rb.rotation, rb.rotation * deltaRotation, speed/2 * Time.deltaTime);
                 
            } else if (Input.GetKey(KeyCode.D))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 90f, 0));
                rb.rotation = Quaternion.Slerp(rb.rotation, rb.rotation * deltaRotation, speed/2 * Time.deltaTime);
            }
        }

    }



    public void Movement_Manager_Update()
    {
        MovementControl_OldInput_Keys();
    }
}

