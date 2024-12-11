using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstScene_name;
    public string creditPageScene_name;
    public string mainMenuScene_name;
    public Animator ani;
    [SerializeField] float time = 0;
    [SerializeField] bool isCountingTime = false;
    [SerializeField] bool isTime = false;
    Status status = Status.none;

    enum Status
    {
        mainmenu, firstscene, credit, exit, none
    }

    public bool isMainMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(firstScene_name);
    }

    public void OpenCredit()
    {
        SceneManager.LoadScene(creditPageScene_name);
    }
    public void Exit()
    {
        Application.Quit();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    private void Update()
    {
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
                    case Status.mainmenu:
                        SceneManager.LoadScene(mainMenuScene_name);
                        break;
                    case Status.firstscene:
                        SceneManager.LoadScene(firstScene_name);
                        break;
                    case Status.credit:
                        SceneManager.LoadScene(creditPageScene_name);
                        break;
                    case Status.exit:
                        Application.Quit();
                        break;
                    default:
                        break;
                }

            }


        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isMainMenu)
            {
                ani.SetBool("isPlay", true);
                isCountingTime = true;

                status = Status.mainmenu;

            }
            else
            {
                ani.SetBool("isPlay", true);
                isCountingTime = true;

                status = Status.firstscene;


            }

        }

        if (Input.GetKeyDown(KeyCode.Q) && creditPageScene_name != null)
        {
            ani.SetBool("isPlay", true);
            isCountingTime = true;

            status = Status.credit;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ani.SetBool("isPlay", true);
            isCountingTime = true;

            status = Status.exit;

        }
    }
}
