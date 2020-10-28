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

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void presentQuestion(){
        wallContainer.SetActiveRecursively(true);
        question = new PMQuestion();
        statementText.GetComponent<Text>().text = question.Statement;
        if (question.Type.CompareTo(PMQuestion.CANNON_TYPE) == 0){
            //Definir los parametros de la pared y el objetivo
            Debug.Log("Mala suerte");
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

    public static bool questionAnswered(){
        if (TargetController.hit && WallController.hit) return true;
        else return false;
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

}
