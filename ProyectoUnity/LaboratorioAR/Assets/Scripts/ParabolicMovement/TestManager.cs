using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

    private PMQuestion question;
    public GameObject statementText;
    public GameObject cannonAngleController;
    public GameObject cannonVelocityController;
    public GameObject wallHeightController;
    public GameObject wallDistanceController;
    public GameObject targetController;
    public GameObject wallToggle;
    public GameObject targetToggle;
    public GameObject wallContainer;


    public void presentQuestion(){
        wallContainer.SetActiveRecursively(true);
        question = new PMQuestion();
        statementText.GetComponent<Text>().text = question.Statement;
        if (question.Type.CompareTo(PMQuestion.CANNON_TYPE) == 0){
            cannonAngleController.transform.GetChild(0).GetComponent<Slider>().value = question.Angle;
            cannonVelocityController.transform.GetChild(0).GetComponent<Slider>().value = question.Velocity;
            wallHeightController.transform.GetChild(0).GetComponent<Slider>().value = question.MaxHeight;
            wallDistanceController.transform.GetChild(0).GetComponent<Slider>().value = question.MidlePoint;
            targetController.transform.GetChild(0).GetComponent<Slider>().value = question.MaxDistance;
            prepareCannonUI();
        } else if (question.Type.CompareTo(PMQuestion.WALL_TYPE) == 0){
            cannonAngleController.transform.GetChild(0).GetComponent<Slider>().value = question.Angle;
            cannonVelocityController.transform.GetChild(0).GetComponent<Slider>().value = question.Velocity;
            wallHeightController.transform.GetChild(0).GetComponent<Slider>().value = 10f;
            wallDistanceController.transform.GetChild(0).GetComponent<Slider>().value = 10f;
            targetController.transform.GetChild(0).GetComponent<Slider>().value = 20f;
            prepareWallUI();
        }
    }

    private void prepareCannonUI(){
        statementText.SetActive(true);
        wallToggle.SetActive(false);
        targetToggle.SetActive(false);
        wallHeightController.SetActive(false);
        wallDistanceController.SetActive(false);
        targetController.SetActive(false);
    }

    private void prepareWallUI(){
        statementText.SetActive(true);
        wallToggle.SetActive(false);
        targetToggle.SetActive(false);
        cannonAngleController.SetActive(false);
        cannonVelocityController.SetActive(false);
    }

    public void questionAnswered(){
        question.solved = TargetController.hit && WallController.hit;
    }

    public void endReview(){
        statementText.SetActive(false);
        wallToggle.SetActive(true);
        targetToggle.SetActive(true);
        wallHeightController.SetActive(true);
        wallDistanceController.SetActive(true);
        targetController.SetActive(true);
        cannonAngleController.SetActive(true);
        cannonVelocityController.SetActive(true);
    }

    public PMQuestion Question { get => question; set => question = value; }

}
