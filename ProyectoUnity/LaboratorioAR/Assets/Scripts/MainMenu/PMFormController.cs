using UnityEngine;
using UnityEngine.UI;

public class PMFormController : MonoBehaviour {
    
    public Dropdown type;
    public InputField angle;
    public InputField velocity;
    public InputField targetDistance;
    public InputField wallHeight;
    public InputField wallDistance;

    public PMQuestion generateQuestion(){
        string type = this.type.options[this.type.value].text;
        float angle = float.Parse(this.angle.text);
        float velocity = float.Parse(this.velocity.text);
        float targetDistance = float.Parse(this.targetDistance.text);
        float wallHeight = float.Parse(this.wallHeight.text);
        float wallDistance = float.Parse(this.wallDistance.text);
        return new PMQuestion(type, angle, velocity, targetDistance, wallHeight, wallDistance, 9.8f);
    }

    public void hiddeOptions(int value){
        if(value == 0){
            angle.interactable = false;
            velocity.interactable = false;
            targetDistance.interactable = true;
            wallHeight.interactable = true;
            wallDistance.interactable = true;
        } else if (value == 1){
            angle.interactable = true;
            velocity.interactable = true;
            targetDistance.interactable = false;
            wallHeight.interactable = false;
            wallDistance.interactable = false;
        }
    }

}
