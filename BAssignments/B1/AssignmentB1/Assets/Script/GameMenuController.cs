using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class GameMenuController : MonoBehaviour
{

    public Button partOneButton;
    public Button partTwoButton;
    public Button partThreeButton;


    private Button.ButtonClickedEvent partOneStart;
    private Button.ButtonClickedEvent partTwoStart;
    private Button.ButtonClickedEvent partThreeStart;

    // Use this for initialization
    void Start()
    {
        if (partOneStart == null || partTwoStart == null || partThreeStart == null)
        {
            partOneStart = new Button.ButtonClickedEvent();
            partTwoStart = new Button.ButtonClickedEvent();
            partThreeStart = new Button.ButtonClickedEvent();
        }
        partOneStart.AddListener(LoadPartOne);
        partTwoStart.AddListener(LoadPartTwo);
        partThreeStart.AddListener(LoadPartThree);

        partOneButton.onClick = partOneStart;
        partTwoButton.onClick = partTwoStart;
        partThreeButton.onClick = partThreeStart;
    }



    void LoadPartOne()
    {
        Application.LoadLevel("AssignmentB1");
    }
    
    void LoadPartTwo()
    {
        Application.LoadLevel("AssignmentB1");
    }
    
    void LoadPartThree()
    {
        Application.LoadLevel("AssignmentB1");
    }
}

