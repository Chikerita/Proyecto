using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

    public PMQuestion question;
    public GameObject statementText;
    public GameObject cannonAngleController;
    public GameObject cannonVelocityController;
    public GameObject wallHeightController;
    public GameObject wallDistanceController;
    public GameObject targetController;
    public GameObject wallToggle;
    public GameObject targetToggle;
    public GameObject wallContainer;

    public void presentRandomQuestion(){
        float angle = Random.Range(20.0f, 75.0f);
        float velocity = Random.Range(15.0f, 27.0f);
        string type;
        float maxDistance;
        float maxHeight;
        float midlePoint;
        float gravity;
        string statement;
        if(Random.Range(0f, 1f) > 0.5f){        //Comentar para debug
//        if(true){
            type = PMQuestion.CANNON_TYPE;
            maxDistance = 0.2038f * Mathf.Pow(velocity, 2) * Mathf.Sin((angle * Mathf.PI) / 180) * Mathf.Cos((angle * Mathf.PI) / 180);
            maxHeight = Mathf.Pow(velocity * Mathf.Sin((angle * Mathf.PI) / 180), 2) / 19.62f;
            midlePoint = maxDistance / 2f;
            gravity = -9.81f;
            angle = 45f;                        //Comentar estas lineas para debug
            velocity = 25f;                     //
            statement = string.Format("Prepare el cañon para disparar un proyectil que pase por encima de la pared que mide {0}m y esta a {1}m, y "+
                                        "golpee el objetivo que se encuentra a {2}m", maxHeight.ToString("F3"), midlePoint.ToString("F3"), maxDistance.ToString("F3"));
        } else {
            type = PMQuestion.WALL_TYPE;
            maxDistance = 50f;
            maxHeight = 15f;
            midlePoint = 25f;
            gravity = -9.81f;
            statement = string.Format("El cañon esta dispuesto para disparar a una velociadad de {0} a un angulo de {1},"+
                                        "coloque el objetivo en la distancia maxima y la apertura de la pared a la altura maxima", velocity.ToString("F3"), angle.ToString("F3"));
        }
        presentQuestion(new PMQuestion(type, angle, velocity, maxDistance, maxHeight, midlePoint, gravity));
    }

    public void presentQuestion(PMQuestion question){
        this.question = question;
        wallContainer.SetActiveRecursivelyExt(true);
        statementText.GetComponent<Text>().text = question.Statement;
        cannonAngleController.transform.GetChild(0).GetComponent<Slider>().value = question.Angle;
        cannonVelocityController.transform.GetChild(0).GetComponent<Slider>().value = question.Velocity;
        wallHeightController.transform.GetChild(0).GetComponent<Slider>().value = question.MaxHeight;
        wallDistanceController.transform.GetChild(0).GetComponent<Slider>().value = question.MidlePoint;
        targetController.transform.GetChild(0).GetComponent<Slider>().value = question.MaxDistance;
        resetUI();
        if (question.Type.CompareTo(PMQuestion.CANNON_TYPE) == 0){
            prepareCannonUI();
        } else if (question.Type.CompareTo(PMQuestion.WALL_TYPE) == 0){
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

    private void resetUI(){
        wallToggle.SetActive(true);
        targetToggle.SetActive(true);
        wallHeightController.SetActive(true);
        wallDistanceController.SetActive(true);
        targetController.SetActive(true);
        cannonAngleController.SetActive(true);
        cannonVelocityController.SetActive(true);
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
        wallContainer.SetActiveRecursivelyExt(false);
        wallContainer.SetActive(true);
        wallContainer.transform.GetChild(0).gameObject.SetActive(true);
    }

}
