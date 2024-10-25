using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Enums_Library;

public class S_Game_Centre : MonoBehaviour
{
    public ScriptableObjects scriptableObjects;
    [Serializable]
    public class ScriptableObjects
    {
        public SO_InputDetails_SOF inputDetails;
        public SO_MovementControls_SOF movementControls;
    }

    public struct InputDetails_Return_Result
    {
        public InputMethod inputMethod;
    }

    public InputDetails_Return_Result InputDetails_Return()
    {
        InputDetails_Return_Result result = new InputDetails_Return_Result
        {
            inputMethod = scriptableObjects.inputDetails.inputMethod
        };

        return result;
    }

    public struct MovementControls_Return_Result
    {
        public float speed;
    }
    public MovementControls_Return_Result MovementControls_Return()
    {
        MovementControls_Return_Result result = new MovementControls_Return_Result
        {
            speed = scriptableObjects.movementControls.movements.speed
        };
        return result;
    }

    public static S_Game_Centre game_Centre { get; private set; }

    private void Awake()
    {
        if (game_Centre != null && game_Centre != this)
        {
            Destroy(this);
        }
        else
        {
            game_Centre = this;
        }
    }
}

