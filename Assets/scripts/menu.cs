using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void onPlayButton()
    {
        //Debug.Log("Inside Play :  " + CarSpawner.Instance.delaytimer);
        
        SceneManager.LoadScene(1);
    } 
    public void onQuitButton()
    {
        Application.Quit();
    }
    public void onlevelButton()
    {
        SceneManager.LoadScene(3);
    }
}
