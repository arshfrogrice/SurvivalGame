using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    public void LoadMenu(){
        Time.timeScale=1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame(){
	   Application.Quit();
	   Debug.Log ("Quit");



    }
}
