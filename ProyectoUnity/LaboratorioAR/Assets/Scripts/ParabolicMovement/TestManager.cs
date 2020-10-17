using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

    private PMQuestion question;
    [SerializeField] Text statementText;
    [SerializeField] GameObject cannonAngleController;
    [SerializeField] GameObject cannonVelocityController;
    [SerializeField] GameObject wallHeightController;
    [SerializeField] GameObject wallDistanceController;
    [SerializeField] GameObject targetController;
    [SerializeField] GameObject wallToggle;
    [SerializeField] GameObject targetToggle;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void presentQuestion(){
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
        statementText.enabled = true;
        wallToggle.SetActive(false);
        targetToggle.SetActive(false);
        wallHeightController.SetActive(false);
        wallDistanceController.SetActive(false);
        targetController.SetActive(false);
    }

    private void prepareWallUI(){
        statementText.enabled = true;
        wallToggle.SetActive(false);
        targetToggle.SetActive(false);
        cannonAngleController.SetActive(false);
        cannonVelocityController.SetActive(false);
    }

    private void questionAnswered(){

    }

}
