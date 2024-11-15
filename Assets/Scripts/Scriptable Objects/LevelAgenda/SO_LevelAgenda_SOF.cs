using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static S_Game_Centre;

[CreateAssetMenu(fileName = "LevelAgenda", menuName = "ScriptableObjects/LevelAgenda")]
public class SO_LevelAgenda_SOF : ScriptableObject
{
    public string level_name;
    public int collect_total;
}
