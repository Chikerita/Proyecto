using UnityEngine;

public class WallController : MonoBehaviour {

    public static bool hit;

    public void changeHeight(float value){
        transform.parent.localPosition = new Vector3(transform.parent.localPosition.x, value - 15.7f, transform.parent.localPosition.z);
    }

    public void changeDistance(float value){
        transform.parent.localPosition = new Vector3(value, transform.parent.localPosition.y, transform.parent.localPosition.z);
    }

    public void resetColision(){
        hit = false;
    }
}
