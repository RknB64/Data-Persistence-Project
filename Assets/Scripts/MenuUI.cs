using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    public Text playerName;
    public Text bestScoreText;
    
    private void Start()
    {
        MenuManager.Instance.LoadBest();
        bestScoreText.text = $"Best Score : {MenuManager.Instance.maxScorer} : {MenuManager.Instance.bestScore}";
    }

    private void Update()
    {
        MenuManager.Instance.currentPlayer = playerName.text.ToString();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveBest();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}