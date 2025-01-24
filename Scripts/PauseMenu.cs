using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;  
    public GameObject OptionsMenuUI;
    public GameObject ControlsMenuUI;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();  
            }
            else
            {
                Pause();  
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);  
        Time.timeScale = 1f;  
        GameIsPaused = false;  
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;  
        GameIsPaused = true;  
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadMenu(){
        Time.timeScale=1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame(){
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    public void OpenOptions()
    {
    PauseMenuUI.SetActive(false);  
    OptionsMenuUI.SetActive(true); 
    }

    public void CloseOptions()
    {
    OptionsMenuUI.SetActive(false); 
    PauseMenuUI.SetActive(true);   
    }
    public void OpenControls()
    {
    PauseMenuUI.SetActive(false);  
    ControlsMenuUI.SetActive(true);
    }

    public void CloseControls()
    {
    ControlsMenuUI.SetActive(false); 
    PauseMenuUI.SetActive(true);   
    }
}