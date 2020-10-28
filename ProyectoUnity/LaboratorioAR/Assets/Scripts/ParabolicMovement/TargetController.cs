using UnityEngine;

public class TargetController : MonoBehaviour {

    public static bool hit;

    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.name.CompareTo("Bullet") == 0){
            hit = true;
        }
    }

    public void changeDistance(float value){
        gameObject.transform.position = new Vector3(value, transform.position.y, transform.position.z);
    }

}
