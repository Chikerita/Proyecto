
[System.Serializable]
public class Questionary {

    public string questionaryName;
    public PMQuestion [] questions;

    public Questionary(string name){
        questionaryName = name;
    }
}
