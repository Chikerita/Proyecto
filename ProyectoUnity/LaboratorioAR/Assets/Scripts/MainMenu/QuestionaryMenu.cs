using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestionaryMenu : MonoBehaviour {
    void OnEnable(){
        StartCoroutine(GetText());
    }
 
    IEnumerator GetText() {
        UnityWebRequest req = UnityWebRequest.Get("http://localhost:3000/get");
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if(req.isNetworkError || req.isHttpError) {
            Debug.Log(req.error);
        } else {
            Debug.Log(req.downloadHandler.text);
        }
    }
}
