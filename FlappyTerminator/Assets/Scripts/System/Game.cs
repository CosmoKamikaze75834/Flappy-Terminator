using UnityEngine;

public class Game : MonoBehaviour
{
    private const float TimePause = 0;
    private const float TimePlay = 1f;

    [SerializeField] private Player _player;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private RestartScreen _endScreen;

    [SerializeField] private GameResetter _gameResetter;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;

        _player.Died += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;

        _player.Died -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = TimePause;

        _endScreen.Close();
        _startScreen.Open();

        _player.DisableControl();
    }

    private void OnGameOver()
    {
        Time.timeScale = TimePause;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _gameResetter.PrepareNewGame();
        Time.timeScale = TimePlay;
        _player.EnableControl();
    }
}