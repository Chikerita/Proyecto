using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

    public Canvas UI;
    private float angle;
    private float initialVelocity;
    private float maxHeight;
    private float maxDistance;
    private float flightTime;
    private bool flying;

    // Start is called before the first frame update
    void Start(){
        angle = 45f;
        initialVelocity = 20f;
        maxHeight = 0f;
        maxDistance = 0f;
        flightTime = 0f;
        flying = false;
    }

    // Update is called once per frame
    void Update(){
        if (flying){
            flightTime += Time.deltaTime;
            maxHeight = Mathf.Max(maxHeight, gameObject.transform.localPosition.y);
            maxDistance = Mathf.Max(maxDistance, gameObject.transform.localPosition.x);
            UI.GetComponent<UIController>().updateStats(maxHeight, maxDistance, flightTime);
        }
    }

    void OnCollisionEnter(Collision collisionInfo){
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        flying = false;
        if(UIController.inReview){
            UI.GetComponent<UIController>().checkAnswer();
        }
    }

    //Shoots the bullet whit the proper angle and initial velocity
    public void shoot(){
        UI.transform.GetChild(0).GetComponent<Button>().interactable = false;
        float xComponent = Mathf.Cos((angle * Mathf.PI) / 180) * initialVelocity;
        float yComponent = Mathf.Sin((angle * Mathf.PI) / 180) * initialVelocity;
        Vector3 vector = new Vector3(xComponent, yComponent, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(vector, ForceMode.VelocityChange);
        flying = true;
    }

    public void resetSimulation(){
        UI.GetComponent<UIController>().resetStats();
        gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        UI.transform.GetChild(0).GetComponent<Button>().interactable = true;
        flying = false;
        maxHeight = 0f;
        maxDistance = 0f;
        flightTime = 0f;
    }

    //Updates the angle when it's changed from the slider or the input
    public void updateAngle(float value){
        angle = value;
    }

    //Updates the initial velocity when it's changed from the slider or the input
    public void updateVelocity(float value){
        initialVelocity = value;
    }

}
