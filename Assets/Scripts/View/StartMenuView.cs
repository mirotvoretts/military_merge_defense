using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuView : UIView
{
    [SerializeField] private Button _startButton;

    private const string MainSceneName = "MainScene";

    private void Awake()
    {
        Show();
    }

    public override void Show()
    {
        ResetButtonWith(_startButton, OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(MainSceneName);
    }
}
