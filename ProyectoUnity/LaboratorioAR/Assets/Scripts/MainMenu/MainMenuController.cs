using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelOne(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
