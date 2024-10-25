using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static ES_Enums_Library;
using static ES_Structs_Library;

public class IC_DP_Clicks_Locals : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public M_B_DirectionPad_Manager  directionPad_Manager;
    public Direction direction_display;
    public bool isSelected;
    public bool isHovered;
    public Image image;

    void Response_LeftClick()
    {
        if (isSelected)
        {
            isSelected = false;
            image.color = Color.white;
        }
        else if (!isSelected)
        {
            if (!directionPad_Manager.IsSelectedMax())
            {
                isSelected = true;
                image.color = Color.red;
            }
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected) 
        {
            isHovered = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHovered)
        {
            isHovered = false;
        }
    }

    public DirectionPad_Status DirectionPad_Status_Return()
    {
        DirectionPad_Status result = new DirectionPad_Status
        {
            direction = direction_display,
            isDisplayOn = isSelected
        };

        return result;
    }




}
