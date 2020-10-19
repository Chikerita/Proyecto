using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;
    public TestManager testManager;
    public Button modeButton;
    // Update is called once per frame
    void Update() {
        
    }

    public void pause(){
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resume(){
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void changeMode(){
        resume();
        if(UIController.inReview){
            UIController.inReview = false;
            modeButton.GetComponentInChildren<Text>().text = "Iniciar repaso";
            testManager.endReview();
        } else {
            UIController.inReview = true;
            modeButton.GetComponentInChildren<Text>().text = "Terminar repaso";
            testManager.presentQuestion();
        }
    }

    public void quit(){
        Application.Quit();
    }
}
