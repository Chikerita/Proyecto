using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

    public Canvas UI;
    private float angle;
    private float initialVelocity;
    private float maxHeight;
    private float maxDistance;
    private float flightTime;
    public static bool flying;

    void Start(){
        angle = 45f;
        initialVelocity = 20f;
        maxHeight = 0f;
        maxDistance = 0f;
        flightTime = 0f;
        flying = false;
    }

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
        if (collisionInfo.collider.name.CompareTo("Ground") == 0 && flying) flying = false;
        if (collisionInfo.collider.name.CompareTo("Target") == 0) {
            TargetController.hit = true;
            flying = false;
        }
        if(!UI.transform.GetChild(0).GetComponent<Button>().interactable && UIController.state > 0) UI.GetComponent<UIController>().checkAnswer();
    }

    void OnTriggerEnter(Collider triggerInfo){
        if (triggerInfo.name.CompareTo("WallTrigger") == 0) WallController.hit = true;
    }

    public void shoot(){
        float xComponent = Mathf.Cos((angle * Mathf.PI) / 180) * initialVelocity;
        float yComponent = Mathf.Sin((angle * Mathf.PI) / 180) * initialVelocity;
        Vector3 vector = new Vector3(xComponent, yComponent, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(vector, ForceMode.VelocityChange);
        flying = true;
    }

    public void resetSimulation(){
        gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
        flying = false;
        UI.GetComponent<UIController>().resetStats();
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        maxHeight = 0f;
        maxDistance = 0f;
        flightTime = 0f;
        UI.transform.GetChild(0).GetComponent<Button>().interactable = true;
    }

    public void updateAngle(float value){
        angle = value;
    }

    public void updateVelocity(float value){
        initialVelocity = value;
    }

}
