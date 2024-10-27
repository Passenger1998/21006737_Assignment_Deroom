using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static ES_Enums_Library;
using static ES_Structs_Library;

public class IC_DP_DirectionPadButtons_Locals : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public M_B_DirectionPad_Manager directionPad_Manager;
    public Direction direction_display;
    public bool isClicked;
    public Image image;

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }

    public DirectionPad_Status DirectionPad_Status_Return()
    {
        DirectionPad_Status result = new DirectionPad_Status
        {
            direction = direction_display,
            isClicked = isClicked,
        };

        return result;
    }




}
