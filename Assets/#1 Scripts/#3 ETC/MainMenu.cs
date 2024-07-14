using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI quitGameText;
    public TextMeshProUGUI settingGameText;

    void Start()
    {
        startGameText.GetComponent<Button>().onClick.AddListener(StartGame);
        quitGameText.GetComponent<Button>().onClick.AddListener(QuitGame);
        settingGameText.GetComponent<Button>().onClick.AddListener(SettingGame);
    }

    void StartGame()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene("main");
    }

    void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    void SettingGame()
    {
        Debug.Log("Main Setting");
        SceneManager.LoadScene("setting");
    }
}
