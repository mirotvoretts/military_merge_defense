using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuView : UIView
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private string _mainSceneName = "MainScene";

    private void Awake()
    {
        Show();
    }

    public override void Show()
    {
        ResetButtonWith(_startButton, OnStartButtonClick);
        ResetButtonWith(_tutorialButton, OnTutorialButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(_mainSceneName);
    }
    
    private void OnTutorialButtonClick()
    {
        Application.Quit();
    }
}
