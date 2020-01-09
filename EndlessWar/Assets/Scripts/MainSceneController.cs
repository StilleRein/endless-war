using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public static bool isMainScene = true;
    GameObject exitPanel, tutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        exitPanel = GameObject.Find("ExitPanel");
        exitPanel.SetActive(false);

        tutorialPanel = GameObject.Find("TutorialPanel");
        tutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame(){
        tutorialPanel.SetActive(true);
    }

    public void TutorialOK(){
        isMainScene = false;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        exitPanel.SetActive(true);
    }

    public void ExitConfirmation(Button button)
    {
        if (button.name.Equals("Yes Button"))
        {
            Application.Quit();
        }

        else if(button.name.Equals("No Button"))
        {
            exitPanel.SetActive(false);
        }
    }
}
