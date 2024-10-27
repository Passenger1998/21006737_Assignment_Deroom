using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static ES_Enums_Library;
using static ES_Structs_Library;

public class IC_DS_DisplaySwitch_Locals : MonoBehaviour
{

    public M_B_DisplaySwitch_Manager  directionPad_Manager;
    public Direction direction_display;
    public bool isClicked;
    public Image image;

    public void Response_LeftClick()
    {
        if (isClicked)
        {
            isClicked = false;
            image.color = Color.white;
        }
        else if (!isClicked)
        {
            isClicked = true;
            image.color = Color.red;

        }
    }

    public DirectionPad_Status DirectionPad_Status_Return()
    {
        DirectionPad_Status result = new DirectionPad_Status
        { 
            direction = direction_display,
            isClicked = isClicked
        };

        return result;

    }





}
