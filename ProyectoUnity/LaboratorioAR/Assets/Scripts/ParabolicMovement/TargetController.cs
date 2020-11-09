using UnityEngine;

public class TargetController : MonoBehaviour {

    public static bool hit;

    public void changeDistance(float value){
        gameObject.transform.localPosition = new Vector3(value, transform.localPosition.y, transform.localPosition.z);
    }

    public void resetColision(){
        hit = false;
    }

}
