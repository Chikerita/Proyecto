using UnityEngine;
using UnityEngine.UI;

public class ParabolicMovementTestManager : MonoBehaviour {

    private bool inTest;
    [SerializeField] Text questionLabel;
    [SerializeField] GameObject cannonAngleControllers;
    [SerializeField] GameObject cannonVelocityControllers;
    [SerializeField] GameObject wallControllers;
    [SerializeField] GameObject targetControllers;

    // Start is called before the first frame update
    void Start() {
        //Debug line
        inTest = false;
    }

    // Update is called once per frame
    void Update() {
        if(inTest) {
            questionLabel.GetComponent<Text>().text = getQuestion();
        } else {
            resetUI();
        }
    }

    private string getQuestion() {
        //If the condition is met the question will require to set the cannon to the proper settings to hit the target
        //If the condition is't met the question will require to set the target and the wall to the proper settings
        if(Random.Range(0.0f, 1.0f) >= 0.5f){
            prepareCannonUI();
            
            return "";
        } else {
            prepareWallUI();
            cannonAngleControllers.transform.GetChild(0).GetComponent<Slider>().value = Random.Range(10.0f, 90.0f);
            cannonVelocityControllers.transform.GetChild(0).GetComponent<Slider>().value = Random.Range(0.0f, 100.0f);
            return "El cañon esta dispuesto para disparar a una velociadad de {0} a un angulo de {1}, coloque el objetivo en la distancia maxima y la pared debajo de la altura maxima";
        }
    }

    private void prepareCannonUI(){

    }

    private void prepareWallUI(){

    }

    private void resetUI(){

    }

    public void setInitialState(bool arg) {
        inTest = arg;
    }

    public void changeState() {
        inTest = !inTest;
    }
}
