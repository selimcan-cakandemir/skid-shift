using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    [SerializeField] private CameraController _cameraFollowScript;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.ClickToStart);
    }
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.ClickToStart:
                Time.timeScale = 0;
                break;
            case GameState.Play:
                Time.timeScale = 1;
                break;
            case GameState.TimeRunOut:
                break;
            case GameState.OutOfBound:
                MenuManager.Instance.OpenRestartPanel();
                _cameraFollowScript.enabled = false;
                break;
            case GameState.Victory:
                MenuManager.Instance.OpenNextLevelPanel();
                Debug.Log("Entered victory state");
                break;
        }

        OnGameStateChanged?.Invoke(newState); //Sadece subscribe olan bir metod varsa
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public enum GameState{
    ClickToStart,
    Play,
    TimeRunOut,
    OutOfBound,
    Victory
    }
}