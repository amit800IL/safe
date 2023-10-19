using UnityEngine;


[CreateAssetMenu(fileName = "new Grounding Stage", menuName = "safe/Grounding/new Stage Scriptable Object", order = 0)]
public class GroundingStageScriptableObject : ScriptableObject {
    public int stageNumber;
    public string taskInformation;
    public int numberOfChoicesToPass;
    public string [] buttonsOptions;
}
