using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class QuestionaryMenu : MonoBehaviour {

    public GameObject buttonPrefab;
    public Transform listviewContent;
    public QuestionaryHandler questionaryHandler;

    void OnEnable(){
        //StartCoroutine(GetQuestionarys());





        Questionary [] arr = {new Questionary()};
        arr[0].questions = new PMQuestion[2];
        arr[0].questions[0] = new PMQuestion(PMQuestion.CANNON_TYPE, 53f, 15f, 22f, 7.32f, 11f, -9.8f);
        arr[0].questions[1] = new PMQuestion(PMQuestion.CANNON_TYPE, 35f, 15f, 60f, 7.32f, 11f, -9.8f);
            foreach (Questionary item in arr){
                GameObject button = (GameObject) Instantiate (buttonPrefab);
			    button.GetComponentInChildren<Text>().text = item.questionaryName;
			    button.GetComponent<Button>().onClick.AddListener(() => {
                    QuestionaryHandler.questionary = item;
                    questionaryHandler.startQuestionary();
                });
			    button.transform.SetParent(listviewContent, false);
            }
    }
 
    IEnumerator GetQuestionarys() {
        UnityWebRequest req = UnityWebRequest.Get("http://localhost:3000/getp");
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if(req.isNetworkError || req.isHttpError) {
            Debug.Log(req.error);
        } else {
            Debug.Log(req.downloadHandler.text);
            Questionary [] arr = JsonHelper.FromJson<Questionary>("{\"Items\":" + req.downloadHandler.text + "}");
            foreach (Questionary item in arr){
                GameObject button = (GameObject) Instantiate (buttonPrefab);
			    button.GetComponentInChildren<Text>().text = item.questionaryName;
			    button.GetComponent<Button>().onClick.AddListener(() => {
                    QuestionaryHandler.questionary = item;
                    questionaryHandler.startQuestionary();
                });
			    button.transform.SetParent(listviewContent, false);
            }
        }
    }

}

