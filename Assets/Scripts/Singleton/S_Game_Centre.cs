using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ES_Enums_Library;
using UnityEngine.SceneManagement;

public class S_Game_Centre : MonoBehaviour
{
    public Animator ani;
    [SerializeField] float time = 0;
    [SerializeField] bool isCountingTime = false;
    [SerializeField] bool isTime = false;
    Status status = Status.none;

    enum Status
    {
        nextscene, exit, none
    }

    public ScriptableObjects _ScriptableObjects;
    [Serializable]
    public class ScriptableObjects
    {
        public SO_InputDetails_SOF inputDetails;
        public SO_MovementControls_SOF movementControls;
        public List<SO_LevelAgenda_SOF> levelAgenda_list;
        public int levelAgenda_list_int = 0;
    }

    public SceneInfo _SceneInfo;
    [Serializable]
    public class SceneInfo
    {
        public string currentScene_additive_name;
    }

    public struct InputDetails_Return_Result
    {
        public InputMethod inputMethod;
    }

    public InputDetails_Return_Result InputDetails_Return()
    {
        InputDetails_Return_Result result = new InputDetails_Return_Result
        {
            inputMethod = _ScriptableObjects.inputDetails.inputMethod
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
            speed = _ScriptableObjects.movementControls.movements.speed
        };
        return result;
    }
    
    public void LevelUpdate()
    {
        ani.SetBool("isPlay", true);
        isCountingTime = true;  
        status = Status.nextscene;
        
    }

    private void Update()
    {
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        

        if (isCountingTime)
        {
            time += Time.deltaTime;

            if (time >= 2f)
            {
                isTime = true;
                isCountingTime = false;
                time = 0;
                ani.SetBool("isPlay", false);
                switch (status)
                {
                    case Status.nextscene:
                        _ScriptableObjects.levelAgenda_list_int += 1;
                        SceneManager.LoadScene(_ScriptableObjects.levelAgenda_list[_ScriptableObjects.levelAgenda_list_int].level_name);
                        break;
                    case Status.exit:
                        Application.Quit();
                        break;
                    default:
                        break;
                }

            }


        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ani.SetBool("isPlay", true);
            isCountingTime = true;
            status = Status.exit;
        }
    }

    public static S_Game_Centre GameCentre { get; private set; }

    private void Awake()
    {
        if (GameCentre != null && GameCentre != this)
        {
            Destroy(this);
        }
        else
        {
            GameCentre = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //private void Awake()
    //{
    //    if (GameCentre != null && GameCentre != this)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        GameCentre = this;
    //    }
    //}


}

