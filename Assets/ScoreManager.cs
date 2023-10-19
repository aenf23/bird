using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "Score:" + score;
    }
   
    public void  OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0;
    }
}