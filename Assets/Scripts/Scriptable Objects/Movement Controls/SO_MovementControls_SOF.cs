using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Enums_Library;
using static S_Game_Centre;

[CreateAssetMenu(fileName = "MovementControls", menuName = "ScriptableObjects/MovementControls")]
public class SO_MovementControls_SOF : ScriptableObject
{
    public Movements movements;
    [Serializable]
    public class Movements
    {
        public float speed;
    }

    public MovementDetects _MovementDetects;
    [Serializable]
    public class MovementDetects
    {
        public float collectDetectDist;
    }

}

