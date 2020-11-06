using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour{

    public InputField angleInput;
    public Slider angleSlider;
    public InputField velInput;
    public Slider velSlider;
    public InputField heightInput;
    public Slider heightSlider;
    public InputField wallDistanceInput;
    public Slider wallDistanceSlider;
    public InputField targetDistanceInput;
    public Slider targetDistanceSlider;
    public Text statsLabel;
    public TestManager testManager;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject answerMenu;
    public QuestionaryHandler questionaryHandler;
    public static int state = 0; // 0: normal, 1: review, 2: quiz

    void Start(){
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if(QuestionaryHandler.inQuestionary){
            state = 2;
            testManager.presentQuestion(QuestionaryHandler.questionary.questions[QuestionaryHandler.questionIndex]);
            pauseButton.SetActive(false);
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !answerMenu.activeInHierarchy){
            if(!PauseMenuController.isPaused){
                pauseMenu.GetComponent<PauseMenuController>().pause();
            } else {
                pauseMenu.GetComponent<PauseMenuController>().resume();
            }
        }
    }

    public void checkAnswer(){
        answerMenu.SetActive(true);
        testManager.questionAnswered();
        if(testManager.question.solved){
            answerMenu.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Respuesta correcta";
            answerMenu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Siguiente pregunta";
        } else {
            answerMenu.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Respuesta incorrecta";
            answerMenu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Reintentar pregunta";
        }
    }

    public void exitToMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void questionMenu(){
        if(state == 1){
            if(testManager.question.solved) testManager.presentRandomQuestion();
            answerMenu.SetActive(false);
        } else if(state == 2){
            if(testManager.question.solved) questionaryHandler.questionSolved();
        }
    }

    public void updateTargetDistanceInput(float value){
        targetDistanceInput.text = value.ToString();
    }

    public void updateTargetDistanceSlider(string text){
        targetDistanceSlider.value = float.Parse(text);
    }

    public void updateWallHeightInput(float value){
        heightInput.text = value.ToString();
    }

    public void updateWallHeightSlider(string text){
        heightSlider.value = float.Parse(text);
    }

    public void updateWallDistanceInput(float value){
        wallDistanceInput.text = value.ToString();
    }

    public void updateWallDistanceSlider(string text){
        wallDistanceSlider.value = float.Parse(text);
    }

    public void updateAngleInput(float value){
        angleInput.text = value.ToString();
    }

    public void updateAngleSlider(string text){
        angleSlider.value = float.Parse(text);
    }

    public void updateVelocityInput(float value){
        velInput.text = value.ToString();
    }

    public void updateVelocitySlider(string text){
        velSlider.value = float.Parse(text);
    }

    public void updateStats(float yPosition, float xPosition, float flightTime){
        statsLabel.text = string.Format("Ymax: {0}m\nXmax: {1}m\nFlight time: {2}s", yPosition.ToString("F3"), xPosition.ToString("F3"), flightTime.ToString("F3"));
    }

    public void resetStats(){
        statsLabel.text = "Ymax: 0m\nXmax: 0m\nFlight time: 0s";
    }

}
