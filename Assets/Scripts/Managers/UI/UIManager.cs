using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private SequenceData seqData;
    
    [SerializeField] private GameObject[] sequencesPanels;
    [SerializeField] private Button[] sequenceButtons;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    /// <summary>
    /// even called when the player pressed on a level button in the level map.
    /// </summary>
    /// <param name="pressedLevelIndex"></param>
    public void ActivateLevelPanel(int pressedLevelIndex)
    {
        
        //checks if the level is locked or not.
        if (!seqData.HasLevelOpened(pressedLevelIndex - 1))
            return;
        //activate the pressed opened or done level.
        seqData.LevelPanels[pressedLevelIndex - 1].SetActive(true);
        // _levelPanels[pressedLevelIndex - 1].SetActive(true);
    }

    /// <summary>
    /// a method to set sequence data to the current sequence which player had clicked on.
    /// </summary>
    /// <param name="pressedSequenceIndex"></param>
    public void SetSequence(int pressedSequenceIndex)
    {
      //get component of the pressed sequence
      seqData = sequencesPanels[pressedSequenceIndex -1].GetComponent<SequenceData>();
     seqData.Unlock1stLevel();
     //seqData.levelButtons[0].interactable = true;
      //check if the sequence is locked or not
      //activate the 1st level button of the sequence
      
    }
    
    public void EnableSequenceButton(int sequenceIndex)
    {
        sequenceButtons[sequenceIndex - 1].interactable = true;
    }
    public void BackToMenuPanel()
    {
        seqData.LevelPanels[seqData.CurrentPressedLevelBTN].SetActive(false);
    }

    public void OpenNextLevel() // a method to open next level obviously lol
    {
        BackToMenuPanel(); // close the current level panel
       seqData.UnlockNextLevel(); // unlock the next level
        int currentLevelActualIndex = seqData.CurrentPressedLevelBTN + 1; // get the actual current level index
        ActivateLevelPanel(currentLevelActualIndex + 1); // open the next level panel
    }


}
