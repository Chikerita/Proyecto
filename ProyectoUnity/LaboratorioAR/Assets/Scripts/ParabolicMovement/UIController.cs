using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour{

    public InputField angleInput;
    public Slider angleSlider;
    public InputField velInput;
    public Slider velSlider;
    public InputField heightInput;
    public Slider heightSlider;
    public InputField wallDistanceInput;
    public Slider wallDistanceSlider;
    public InputField targetDistanceInput;
    public Slider targetDistanceSlider;
    public Text statsLabel;

    // Start is called before the first frame update
    void Start(){
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            
        }
    }

    public void updateTargetDistanceInput(float value){
        targetDistanceInput.text = value.ToString();
    }

    public void updateTargetDistanceSlider(string text){
        targetDistanceSlider.value = float.Parse(text);
    }

    public void updateWallHeightInput(float value){
        heightInput.text = value.ToString();
    }

    public void updateWallHeightSlider(string text){
        heightSlider.value = float.Parse(text);
    }

    public void updateWallDistanceInput(float value){
        wallDistanceInput.text = value.ToString();
    }

    public void updateWallDistanceSlider(string text){
        wallDistanceSlider.value = float.Parse(text);
    }

    public void updateAngleInput(float value){
        angleInput.text = value.ToString();
    }

    public void updateAngleSlider(string text){
        angleSlider.value = float.Parse(text);
    }

    public void updateVelocityInput(float value){
        velInput.text = value.ToString();
    }

    public void updateVelocitySlider(string text){
        velSlider.value = float.Parse(text);
    }

    public void updateStats(float yPosition, float xPosition, float flightTime){
        statsLabel.text = string.Format("Ymax: {0}m\nXmax: {1}m\nFlight time: {2}s", yPosition.ToString("F3"), xPosition.ToString("F3"), flightTime.ToString("F3"));
    }

    public void resetStats(){
        statsLabel.text = "Ymax: 0m\nXmax: 0m\nFlight time: 0s";
    }

}
