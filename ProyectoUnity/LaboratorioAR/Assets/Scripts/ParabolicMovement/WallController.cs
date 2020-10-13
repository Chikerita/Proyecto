using UnityEngine;

public class WallController : MonoBehaviour {

    public void changeHeight(float value){
        transform.position = new Vector3(transform.position.x, value - 15.7f, transform.position.z);
    }

    public void changeDistance(float value){
        transform.position = new Vector3(value + 6f, transform.position.y, transform.position.z);
    }
}
