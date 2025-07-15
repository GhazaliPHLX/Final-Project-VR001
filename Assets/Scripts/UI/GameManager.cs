using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState = GameState.Playing; // Mengubah state awal menjadi Playing

    public GameObject pauseMenuUI; // Hanya menyisakan pauseMenuUI

    public PlayerInput playerInput;

    public enum GameState
    {
        Playing,
        Paused
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opsional: Agar GameManager tidak hancur saat scene berganti
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SwitchState(GameState.Playing); // Langsung mulai game
    }

    private void Update()
    {
        if (currentState == GameState.Playing)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current?.startButton.wasPressedThisFrame == true)
            {
                PauseGame();
            }
        }
        else if (currentState == GameState.Paused)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current?.startButton.wasPressedThisFrame == true)
            {
                ResumeGame();
            }
        }
    }

    public void SwitchState(GameState newState)
    {
        currentState = newState;

        // Hanya mengelola tampilan pauseMenuUI
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(newState == GameState.Paused);
        }

        // Mengatur Time.timeScale hanya untuk Playing dan Paused
        Time.timeScale = (newState == GameState.Paused) ? 0f : 1f;

        // Mengatur PlayerInput action map
        if (playerInput != null)
        {
            if (newState == GameState.Paused)
            {
                playerInput.SwitchCurrentActionMap("UI");
                Debug.Log("Switched to UI map: " + playerInput.currentActionMap.name);
            }
            else if (newState == GameState.Playing)
            {
                playerInput.SwitchCurrentActionMap("Player");
            }
        }
    }

    public void PauseGame()
    {
        SwitchState(GameState.Paused);
    }

    public void ResumeGame()
    {
        SwitchState(GameState.Playing);
    }

    // Fungsi StartGame, ToMainMenu, dan GameOver dihapus karena tidak ada MainMenu/GameOver
    // Jika Anda ingin kembali ke scene awal, Anda bisa menggunakan SceneManager.LoadScene di tempat lain,
    // atau membuat fungsi terpisah yang memuat ulang scene.
}