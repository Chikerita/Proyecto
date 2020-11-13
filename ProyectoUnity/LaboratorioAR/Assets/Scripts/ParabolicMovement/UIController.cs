using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour{

    public Text statsLabel;
    public TestManager testManager;
    public GameObject answerMenu;
    public GameObject pauseButton;
    public GameObject shootButton;
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

    public void checkAnswer(){
        testManager.questionAnswered();
        answerMenu.SetActive(true);
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

    public void changeShootButtonInteractable(bool interactable){
        shootButton.GetComponent<Button>().interactable = interactable;
    }

    public void updateStats(float yPosition, float xPosition, float flightTime){
        statsLabel.text = string.Format("Ymax: {0}m\nXmax: {1}m\nFlight time: {2}s", yPosition.ToString("F3"), xPosition.ToString("F3"), flightTime.ToString("F3"));
    }

    public void resetStats(){
        statsLabel.text = "Ymax: 0m\nXmax: 0m\nFlight time: 0s";
    }

}
