using UnityEngine;

public class TargetController : MonoBehaviour {

    public static bool hit;

    public void changeDistance(float value){
        gameObject.transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }

    public void resetColision(){
        hit = false;
    }

}
