using UnityEngine;
using DG.Tweening;
using TMPro;
using static GameManager;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _clickToStartMenu, _restartPanel, _nextLevelPanel;
    [SerializeField] private TextMeshProUGUI _score;
    private int _goldPickups;

    void Awake()
    {
        Instance = this;
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    void Update()
    {
        _score.text = _goldPickups + "/9";
    }

    private void OnEnable()
    {
        Actions.OnGoldPickup += OnPickup;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
        Actions.OnGoldPickup -= OnPickup;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState gameState)
    {
        _clickToStartMenu.SetActive(true);
    }

    public void OnPickup()
    {
        ++_goldPickups;
    }

    public void PlayButton()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        _clickToStartMenu.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }

    public void OpenRestartPanel()
    {
        _restartPanel.SetActive(true);
    }

    public void OpenNextLevelPanel()
    {
        _nextLevelPanel.SetActive(true);
    }
}
