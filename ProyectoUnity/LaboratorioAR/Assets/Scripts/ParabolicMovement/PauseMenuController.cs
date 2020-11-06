using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;
    public TestManager testManager;
    public Button modeButton;

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
        if(UIController.state == 1){
            UIController.state = 0;
            modeButton.GetComponentInChildren<Text>().text = "Iniciar repaso";
            testManager.endReview();
        } else {
            UIController.state = 1;
            modeButton.GetComponentInChildren<Text>().text = "Terminar repaso";
            testManager.presentRandomQuestion();
        }
    }

    public void exitToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
