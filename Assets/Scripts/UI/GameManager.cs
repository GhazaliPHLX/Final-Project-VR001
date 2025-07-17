using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Playing, Paused, MainMenu }
    public GameState currentState = GameState.MainMenu;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject HUD;


    [SerializeField] private InputActionReference pauseAction;

    [SerializeField] private string gameSceneName = "MainScene"; // Assign nama scene gameplay kamu di Inspector

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        currentState = GameState.MainMenu;

        mainMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        pauseAction.action.performed += ctx =>
        {
            if (currentState == GameState.Playing)
                ShowPauseUI();
        };
    }

    private void OnEnable() => pauseAction.action.Enable();
    private void OnDisable() => pauseAction.action.Disable();

    public void ShowPauseUI()
    {
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        currentState = GameState.Paused;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        currentState = GameState.Playing;
        Time.timeScale = 1f;
        AudioListener.pause = false;

    }
    public void ReturnToMainMenu()
    {
        AudioListener.pause = false;
        if (!string.IsNullOrEmpty(gameSceneName))
            SceneManager.LoadScene(gameSceneName);
    }

    public void PlayGame()
    {
        HUD.SetActive(true);
        mainMenuUI.SetActive(false);
        currentState = GameState.Playing;

        // Kalau kamu mau load scene baru (misal dari menu ke gameplay), pakai ini:
        
    }

    
}
