using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuData : MonoBehaviour
{
    [Header("List of Main Menus/UI")]
    public List<GameObject> menus = new List<GameObject>();

    [Header("List of Sub Menus/UI")]
    public List<GameObject> settingsMenus = new List<GameObject>();
}
