using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField] private CanvasGroup _menuSceen;
    [SerializeField] private CanvasGroup _loadingSceen;
    
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _exitGame;
    [SerializeField] private Image progressBar;

    enum Screen
    {
        Main,
        Loading,
        None,
    }

    private void Start()
    {
        SetCanvas(Screen.Main);
    }

    private void SetCanvas(Screen screen)
    {
        SwitchingCanvas.SetCanvasGroup(_menuSceen, screen == Screen.Main);
        SwitchingCanvas.SetCanvasGroup(_loadingSceen, screen == Screen.Loading);
    }

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

    public void StartGame()
    {
        SetCanvas(Screen.Loading);
        StartCoroutine(Coroutine("GameScene"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator Coroutine(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            progressBar.fillAmount = operation.progress;
            yield return null;
        }
        SetCanvas(Screen.None);
    }
}
