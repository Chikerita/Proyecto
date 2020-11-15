using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public static bool isPaused = false;
    public TestManager testManager;
    public Button modeButton;
    public Button cameraTypeButton;

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

    public void changeCameraType(){
        UIController.inARMode = !UIController.inARMode;
        Text buttonText = cameraTypeButton.GetComponentInChildren<Text>();
        if (UIController.inARMode) buttonText.text = "Cambiar a 3D";
        else buttonText.text = "Cambiar a AR";
        resume();
    }

    public void exitToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
