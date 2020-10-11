using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public void changeDistance(float value){
        gameObject.transform.position = new Vector3(value + 6f, transform.position.y, transform.position.z);
    }

}
