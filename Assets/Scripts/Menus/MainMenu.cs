﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[RequireComponent(typeof(MenuData))]
public class MainMenu : Singleton<MainMenu>
{
    protected MenuData _data;

    //changes to mainmenu on start
    private void Start()
    {
        _data = GetComponent<MenuData>();
        ChangeMenu("MainMenu");
    }

    //Changes Menu, through button
    public void ChangeMenu(string menu)
    {
        for (int i = 0; i < _data.menus.Count; i++)
            _data.menus[i].SetActive(_data.menus[i].name.Contains(menu));
    }

    //Changes Scene, through button
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Quits the game and closes editor
    public void QuitBtn()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}