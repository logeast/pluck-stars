using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("操作按钮")]

    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    public Button backButton;
    public VisualElement mainMenu;
    public VisualElement optionsMenu;

    private void Awake()
    {
        // 获取根元素
        var root = GetComponent<UIDocument>().rootVisualElement;

        // 给变量赋值
        playButton = root.Q<Button>("PlayButton");
        optionsButton = root.Q<Button>("OptionsButton");
        quitButton = root.Q<Button>("QuitButton");
        backButton = root.Q<Button>("BackButton");
        mainMenu = root.Q<Button>("MainMenu");
        optionsMenu = root.Q<Button>("OptionsMenu");

        // 给按钮指定方法
        playButton.clicked += PlayButtonPressed;
        optionsButton.clicked += OptionsMenuPressed;
        quitButton.clicked += QuitButtonPressed;
        backButton.clicked += BackButtonPressed;
    }

    void PlayButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    void OptionsMenuPressed()
    {
        mainMenu.style.display = DisplayStyle.None;
        optionsMenu.style.display = DisplayStyle.Flex;
    }

    void QuitButtonPressed()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    void BackButtonPressed()
    {
        optionsMenu.style.display = DisplayStyle.None;
        mainMenu.style.display = DisplayStyle.Flex;
    }
}
