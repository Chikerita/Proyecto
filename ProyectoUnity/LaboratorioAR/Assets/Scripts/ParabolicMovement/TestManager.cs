using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

    public PMQuestion question;
    public GameObject statementText;
    public GameObject statisticsText;
    public GameObject cannonController;
    public GameObject wallController;
    public GameObject targetController;
    public GameObject wallContainer;

    public void presentRandomQuestion(){
        float angle = Random.Range(20.0f, 75.0f);
        float velocity = Random.Range(15.0f, 27.0f);
        string type;
        float maxDistance;
        float maxHeight;
        float midlePoint;
        float gravity;
        if(Random.Range(0f, 1f) > 0.5f){        //Comentar para debug
//        if(true){
            type = PMQuestion.CANNON_TYPE;
            maxDistance = 0.2038f * Mathf.Pow(velocity, 2) * Mathf.Sin((angle * Mathf.PI) / 180) * Mathf.Cos((angle * Mathf.PI) / 180);
            maxHeight = Mathf.Pow(velocity * Mathf.Sin((angle * Mathf.PI) / 180), 2) / 19.62f;
            midlePoint = maxDistance / 2f;
            gravity = -9.81f;
            angle = 45f;                        //Comentar estas lineas para debug
            velocity = 25f;                     //
        } else {
            type = PMQuestion.WALL_TYPE;
            maxDistance = 50f;
            maxHeight = 15f;
            midlePoint = 25f;
            gravity = -9.81f;
        }
        presentQuestion(new PMQuestion(type, angle, velocity, maxDistance, maxHeight, midlePoint, gravity));
    }

    public void presentQuestion(PMQuestion question){
        this.question = question;
        wallContainer.SetActiveRecursivelyExt(true);
        statementText.GetComponent<Text>().text = question.Statement;
        cannonController.GetComponent<AtributeController>().firstSlider.value = question.Velocity;
        cannonController.GetComponent<AtributeController>().secondSlider.value = question.Angle;
        wallController.GetComponent<AtributeController>().firstSlider.value = question.MidlePoint;
        wallController.GetComponent<AtributeController>().secondSlider.value = question.MaxHeight;
        targetController.GetComponent<AtributeController>().firstSlider.value = question.MaxDistance;
        resetUI();
        if (question.Type.CompareTo(PMQuestion.CANNON_TYPE) == 0){
            prepareCannonUI();
        } else if (question.Type.CompareTo(PMQuestion.WALL_TYPE) == 0){
            prepareWallUI();
        }
    }

    private void prepareCannonUI(){
        statisticsText.SetActive(false);
        statementText.SetActive(true);
        wallController.SetActive(false);
        targetController.SetActive(false);
    }

    private void prepareWallUI(){
        statisticsText.SetActive(false);
        statementText.SetActive(true);
        cannonController.SetActive(false);
    }

    private void resetUI(){
        wallController.SetActive(true);
        targetController.SetActive(true);
        cannonController.SetActive(true);
    }

    public void questionAnswered(){
        question.solved = TargetController.hit && WallController.hit;
        TargetController.hit = false;
        WallController.hit = false;
    }

    public void endReview(){
        statisticsText.SetActive(true);
        statementText.SetActive(false);
        wallController.SetActive(true);
        targetController.SetActive(true);
        cannonController.SetActive(true);
        wallContainer.SetActiveRecursivelyExt(false);
        wallContainer.SetActive(true);
        wallContainer.transform.GetChild(0).gameObject.SetActive(true);
    }

}
