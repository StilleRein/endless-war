using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameSceneController : MonoBehaviour
{
    public Text ResultScore;
    // Start is called before the first frame update
    void Start()
    {
        ResultScore.text = "Score : " + UIManager.score;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BackToHome()
    {
        MainSceneController.isMainScene = true;
        SceneManager.LoadScene("MainScene");
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }
}
