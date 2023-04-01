using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public float ChangeTime;
    public string sceneName;
    public void StartGame()
    {
        //SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene("OpenCutscene");
    }
    public void LoadGame()
    {
        //Edit Later
        SceneManager.LoadScene("MainScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToEndingsPage()
    {
        SceneManager.LoadScene("EndingCollectScene");
    }
    private void Update()
    {
        ChangeTime -= Time.deltaTime;
        if (ChangeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
