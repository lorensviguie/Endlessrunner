using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Reprendre()
    {
        Debug.Log("ok");
        PausePanel.SetActive(false);
        Time.timeScale = 1 ;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainHud");
    }

    public void Rejouer()
    {
        SceneManager.LoadScene("Scenes/Level");
        Time.timeScale = 1 ;
    } 
}