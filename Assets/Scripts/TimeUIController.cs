using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeUIController : MonoBehaviour
{
    public Label gameTimeLabel;
    public Button pauseGameButton;

    public TimeManager timeManager;
    private bool gamePause = false;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        gameTimeLabel = root.Q<Label>("GameTimeLabel");
        pauseGameButton = root.Q<Button>("PauseGameButton");

        pauseGameButton.clicked += PauseGameButtonPressed;
    }

    private void Update()
    {
        gameTimeLabel.text = timeManager.GetTime();
    }

    private void PauseGameButtonPressed()
    {
        gamePause = !gamePause;
        if (gamePause)
        {
            timeManager.PauseTime();
            pauseGameButton.text = "继续游戏";
        }
        else
        {
            timeManager.ResumeTime();
            pauseGameButton.text = "暂停游戏";
        }
    }
}
