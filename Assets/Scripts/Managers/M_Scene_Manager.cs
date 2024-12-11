using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Structs_Library;
using static ES_Enums_Library;
using System;
using Unity.VisualScripting;
using static M_Scene_Manager;
using static M_V_InputResponse_Manager;
using static M_GamePlay_Manager;
using UnityEngine.SceneManagement;

public class M_Scene_Manager : MonoBehaviour
{
    public ManagerList _ManagerList;
    [Serializable]
    public class ManagerList
    {
        public GamePlay _Gameplay;
        [Serializable]
        public class GamePlay
        {
            public M_GamePlay_Manager GamePlay_Manager;
        }

        public UserInterface userInterface;
        [Serializable]
        public class UserInterface
        {
        }

        public CameraBehaviour cameraBehaviour;
        [Serializable]
        public class CameraBehaviour
        {
            public M_C_CameraFollow_Manager cameraFollow_Manager;
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
            public M_V_InputResponse_Manager inputResponse_Manager;
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

        public Level _Level;
        [Serializable]
        public class Level
        {
            public SO_LevelAgenda_SOF levelSO_this;
            public bool isLevel_passed = false;
            public GameObject pressContinueButton;
        }

        public Items _Items;
        [Serializable]
        public class Items
        {
            public List<L_CollectableItems_Locals> collectableItems_list;
        }
    }

    public void Set_isLevel_passed(bool toggle)
    {
        _References._Level.isLevel_passed = toggle;
    }

    public Rigidbody Rigidbody_Return()
    {
        return _References._Players.rb;
    }
    public GameObject Player_Return()
    {
        return _References._Players.player;
    }

    private void LevelPass_React()
    {
        if (_References._Level.isLevel_passed)
        {

            _References._Level.pressContinueButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                S_Game_Centre.GameCentre.LevelUpdate();
            }
            
            
        }
    }

    void SceneManager_Initialize()
    {

        L_CollectableItems_Locals[] collectableItems_Locals_array = FindObjectsOfType<L_CollectableItems_Locals>();
        foreach (L_CollectableItems_Locals i in collectableItems_Locals_array)
        {
            _References._Items.collectableItems_list.Add(i);
        }

    }
    private void Awake()
    {
        SceneManager_Initialize();

        M_V_InputResponse_Manager.VisualManager_Initialize_Data visualmanager_initialize_data = new M_V_InputResponse_Manager.VisualManager_Initialize_Data
        {
            slider_initialize_data = new M_V_InputResponse_Manager.Slider_Initialize_Data
            {
                value_max = _References._Level.levelSO_this.collect_total
            }

        }; 
        _ManagerList.visualEffects.inputResponse_Manager.VisualManager_Initialize(visualmanager_initialize_data);
    }

    private void Update()
    {
        _ManagerList.inputControl.movement_Manager.Movement_Manager_Update();
        _ManagerList.cameraBehaviour.cameraFollow_Manager.CameraFollow_Manager_Update();

        M_V_InputResponse_Manager.VisualManager_Update_Data visualmanager_update_data = new M_V_InputResponse_Manager.VisualManager_Update_Data
        {
            slider_sync_data = new M_V_InputResponse_Manager.Slider_Sync_Data
            { 
                value_current = _ManagerList._Gameplay.GamePlay_Manager.ItemCollect_Count_Get()
            }

        };
        _ManagerList.visualEffects.inputResponse_Manager.VisualManager_Update(visualmanager_update_data);

        M_GamePlay_Manager.Scene_Manager_Update_Data scene_Manager_Update_Data = new Scene_Manager_Update_Data
        {
            itemCollect_Detect_Data = new ItemCollect_Detect_Data
            {
                collectableItems_Locals_list = _References._Items.collectableItems_list
            }
        };
        _ManagerList._Gameplay.GamePlay_Manager.GamePlayManager_Update(scene_Manager_Update_Data);

        LevelPass_React();
    }
}
