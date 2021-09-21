using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private HealthShip ship;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    private CanvasGroup canvas;

    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 0f;
    }

    private void OnEnable()
    {
        ship.Died += OnDie;
        _restart.onClick.AddListener(RestartGame);
        _exit.onClick.AddListener(ExitFromApplication);
    }
    private void OnDisable()
    {
        ship.Died -= OnDie;
        _restart.onClick.RemoveListener(RestartGame);
        _exit.onClick.RemoveListener(ExitFromApplication);
    }

    private void OnDie()
    {
        canvas.alpha = 1f;
        Time.timeScale = 0f;
    }
    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
        canvas.alpha = 0f;
    }
    private void ExitFromApplication()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
}
