using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton ()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void MenutButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
