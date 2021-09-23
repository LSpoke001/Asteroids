using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public CanvasGroup pauseCanvas;
    private CanvasGroup mainCanvas;
    public Button backGame;
    public Button menu;

    private Button pauseButton;
    private void OnEnable()
    {
        backGame.onClick.AddListener(BackToGame);
        menu.onClick.AddListener(ExitFromApplication);
    }
    private void OnDisable()
    {
        backGame.onClick.RemoveListener(BackToGame);
        menu.onClick.RemoveListener(ExitFromApplication);
    }
    private void Start()
    {
        pauseCanvas.alpha = 0f;
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseGame);
        mainCanvas = GetComponentInParent<CanvasGroup>();
        mainCanvas.alpha = 1f;
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.alpha = 1f;
        mainCanvas.alpha = 0f;
    }
    private void BackToGame()
    {
        pauseCanvas.alpha = 0f;
        Time.timeScale = 1f;
        mainCanvas.alpha = 1f;
    }
    private void ExitFromApplication()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
}
