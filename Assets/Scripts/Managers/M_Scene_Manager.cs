using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Structs_Library;
using static ES_Enums_Library;
using System;
using Unity.VisualScripting;

public class M_Scene_Manager : MonoBehaviour
{
    public ManagerList _ManagerList;
    [Serializable]
    public class ManagerList
    {
        
        public UserInterface userInterface;
        [Serializable]
        public class UserInterface
        {
        }

        public CameraBehaviour cameraBehaviour;
        [Serializable]
        public class CameraBehaviour
        {
            public M_C_CameraSwtich_Manager cameraSwtich_Manager;
        }

        public InputControl inputControl;
        [Serializable]
        public class InputControl
        {
            public M_I_Movement_Manager movement_Manager;
            
        }

        public VisualEffects visualEffects;
        [Serializable]
        public class VisualEffects
        {
            public V_InputResponse_Manager inputResponse_Manager;
        }

    }

    public References _References;
    [Serializable]
    public class References
    {

        public Players _Players;
        [Serializable]
        public class Players
        {
            public GameObject player;
            public Rigidbody rb;
        }
    }

    public Rigidbody Rigidbody_Return()
    {
        return _References._Players.rb;
    }

    private void Update()
    {
        _ManagerList.inputControl.movement_Manager.Movement_Manager_Update();
    }
}
