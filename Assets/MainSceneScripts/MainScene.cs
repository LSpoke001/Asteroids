using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _exitGame;

    private void OnEnable()
    {
        _startGame.onClick.AddListener(StartGame);
        _exitGame.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _startGame.onClick.RemoveListener(StartGame);
        _exitGame.onClick.RemoveListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
