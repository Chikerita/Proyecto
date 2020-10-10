using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
        
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void changeHeight(float value){
        transform.position = new Vector3(transform.position.x, value - 15.1f, transform.position.z);
    }

    public void changeDistance(float value){
        transform.position = new Vector3(value + 6f, transform.position.y, transform.position.z);
    }
}
