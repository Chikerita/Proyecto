using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    private string[] simulations = {"ParabolicMovement"};
    public Transform menuPanel;
    public GameObject buttonPrefab;

    void Start(){
        Screen.orientation = ScreenOrientation.Portrait;
		for (int i = 0; i < simulations.Length; i++){
			GameObject button = (GameObject) Instantiate (buttonPrefab);
			button.GetComponentInChildren<Text>().text = simulations[i];
			int index = i;
			button.GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.LoadScene(button.GetComponentInChildren<Text>().text);
            });
			button.transform.SetParent(menuPanel, false);
		}
    }
    
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            QuitGame();

        }
    }

    public void LoadLevelOne(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
