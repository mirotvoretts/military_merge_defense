using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuView : UIView
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private const string MainSceneName = "MainScene";

    private void Awake()
    {
        Show();
    }

    public override void Show()
    {
        ResetButtonWith(_startButton, OnStartButtonClick);
        ResetButtonWith(_exitButton, OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(MainSceneName);
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
