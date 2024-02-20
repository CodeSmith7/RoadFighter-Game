using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    public GameObject easy;
    public GameObject medium;
    public GameObject hard;

    public void easyLevel()
    {
        CarSpawner.delaytimer = 1.3f;
        Debug.Log(CarSpawner.delaytimer);
        SceneManager.LoadScene(0);
        Debug.Log("last" + CarSpawner.delaytimer);

    }
    public void mediumLevel()
    {
        CarSpawner.delaytimer = 1f;
        Debug.Log(CarSpawner.delaytimer);
        SceneManager.LoadScene(0);

    }
    public void hardLevel() 
    {
        CarSpawner.delaytimer = 0.6f;
        Debug.Log(CarSpawner.delaytimer);
        SceneManager.LoadScene(0);

    }
    
}
