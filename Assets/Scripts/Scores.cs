using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    [SerializeField] GameObject winUI;
    
    [SerializeField] GameObject yourScoreLabel;
    [SerializeField] GameObject yourTimeLabel;
    [SerializeField] GameObject bestScoreLabel;
    [SerializeField] GameObject bestTimeLabel;

    [SerializeField] GameObject newHighScore;
    [SerializeField] GameObject newBestTime;

    [SerializeField] GameObject p1Camera;
    [SerializeField] GameObject p2Camera;

    [SerializeField] GameObject p1Screen;
    [SerializeField] GameObject p2Screen;

    private float highScore;
    private float bestTime;

    private bool zoomOut;

    private void FixedUpdate()
    {
        if (zoomOut)
        {

            if (p1Camera.GetComponent<Camera>().orthographicSize < 50)
            {

                p1Camera.GetComponent<Camera>().orthographicSize += (0.1f);
                p2Camera.GetComponent<Camera>().orthographicSize += (0.1f);
            }

            if (p1Screen.transform.localScale.x > 0.5f)
            {
                p1Screen.transform.localScale += new Vector3(-0.01f, -0.01f, -0.01f);
                p2Screen.transform.localScale += new Vector3(-0.01f, -0.01f, -0.01f);
            }

            if (p1Screen.transform.localPosition.y > -110)
            {
                p1Screen.transform.localPosition += new Vector3(0, -1f, 0);
            }
            if (p1Screen.transform.localPosition.x < 0)
            {
                p1Screen.transform.localPosition += new Vector3(1f, 0, 0);
            }

            if (p2Screen.transform.localPosition.y < 110)
            {
                p2Screen.transform.localPosition = p2Screen.transform.localPosition + new Vector3(0, 1f, 0);
            }
            else if (p2Screen.transform.localPosition.x > 0)
            {
                p2Screen.transform.localPosition += new Vector3(-1f, 0, 0);
            }
        }

    }

    public void UpdateScores(float score, float time)
    {
        //Time.timeScale = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            highScore = 0;
        }

        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTime = Mathf.Infinity;
        }

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            newHighScore.SetActive(true);
        }
        if (time < bestTime)
        {
            bestTime = time;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            newBestTime.SetActive(true);
        }

        winUI.SetActive(true);

        yourScoreLabel.GetComponent<TextMeshProUGUI>().text = "Your Score Was: " + string.Format("{0:0.00}", score);
        yourTimeLabel.GetComponent<TextMeshProUGUI>().text = "Your Time Was: " + string.Format("{0:0.00}", time) + "Seconds";
        bestScoreLabel.GetComponent<TextMeshProUGUI>().text = "Best Score Was: " + string.Format("{0:0.00}", highScore);
        bestTimeLabel.GetComponent<TextMeshProUGUI>().text = "Best Time Was: " + string.Format("{0:0.00}", bestTime) + " Seconds";

        zoomOut = true;
    }

    public void ZoomOut()
    {
        
        
        //Camera.main.transform.position;
    }
}
