using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class T_M_001_001_All : MonoBehaviour
{



    #region Control
    public Direction direction_current;
    public InputMethod inputMethod;
    public GameObject player;
    public bool isMoving = false;
    public float speed;

    [Serializable]
    public enum Direction
    {
        front, back, left, right,none
    }

    [Serializable]
    public enum InputMethod
    {
        developerdebug, oldinput, newinput
    }

    public struct B_PlayerControl_Data
    {
        public InputMethod inputMethod;

        public bool isMoving;
        public float speed;
        public GameObject player;
    }

    public struct B_PlayerControl_Result
    { }

    public void B_PlayerControl(B_PlayerControl_Data data)
    {
        InputMethod inputMethod_local = data.inputMethod;

        F_InputMove_Data data_result_F_InputMove = new F_InputMove_Data
        {
            inputMethod = inputMethod_local,

        };
        F_InputMove_Result result_F_InputMove = F_InputMove(data_result_F_InputMove);


    }

    public struct F_InputMove_Data
    {
        public InputMethod inputMethod;
        public bool isMoving;
        public float speed;
        public GameObject player;
    }

    public struct F_InputMove_Result
    {
        public Direction direciton;
        public bool isMoving;
    }

    public F_InputMove_Result F_InputMove
        (F_InputMove_Data data)
    {

        InputMethod inputMethod_local = data.inputMethod;
        bool isMoving_local = data.isMoving;
        float speed_local = data.speed;
        GameObject player_local = data.player;
        F_InputMove_Result result = new F_InputMove_Result();

        Direction direction_local = Direction.none;
        switch (inputMethod_local)
        {
            case InputMethod.developerdebug:
                {
                    #region input enter
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        direction_local = Direction.front;
                        isMoving_local = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        direction_local = Direction.back;
                        isMoving_local = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        direction_local = Direction.left;
                        isMoving_local = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        direction_local = Direction.right;
                        isMoving_local = true;
                    }
                    else
                    {
                        direction_local = Direction.none;
                        isMoving_local = false;
                    }
                    #endregion
                    #region input hold
                    if (Input.GetKey(KeyCode.A)
                        && direction_local == Direction.front)
                    {
                        player_local.transform.position += new Vector3(0, 0, speed_local) * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.W)
                        && direction_local == Direction.back)
                    {
                        player_local.transform.position += new Vector3(0, 0, -speed_local) * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.A)
                        && direction_local == Direction.left)
                    {
                        player_local.transform.position += new Vector3(-speed_local, 0, 0) * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.D)
                        && direction_local == Direction.right)
                    {
                        player_local.transform.position += new Vector3(speed_local, 0, 0) * Time.deltaTime;
                    }
                    else
                    {
                        direction_local = Direction.none;
                    }
                    #endregion
                };
                break;
        }

        result.direciton = direction_local;
        return result;
    }

    public struct F_SlowRotation_Data
    {
        InputMethod inputMethod;
        GameObject player;
    }

    public struct F_SlowRotation_Result
    {

    }

    public void F_SlowRotation(F_SlowRotation_Data data)
    {
        
    }
    #endregion

    private void Update()
    {

        B_PlayerControl(inputMethod);
    }
}
