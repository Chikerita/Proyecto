using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    private string[] simulations = {"ParabolicMovement"};
    private bool simulationsLoaded = false;
    public Transform menuPanel;
    public GameObject buttonPrefab;

    void Start(){
        Screen.orientation = ScreenOrientation.Portrait;
    }
    
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            QuitGame();
        }
    }

    public void loadSimulationsList(){
        if (!simulationsLoaded){
		    for (int i = 0; i < simulations.Length; i++){
			    GameObject button = (GameObject) Instantiate (buttonPrefab);
			    button.GetComponentInChildren<Text>().text = simulations[i];
			    button.GetComponent<Button>().onClick.AddListener(() => {
                    SceneManager.LoadScene(button.GetComponentInChildren<Text>().text);
                });
			    button.transform.SetParent(menuPanel, false);
		    }
            simulationsLoaded = true;
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
