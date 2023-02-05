using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    [SerializeField] GameObject winUI;
    [SerializeField] GameObject uiLabel;

    [SerializeField] GameObject yourScoreLabel;
    [SerializeField] GameObject yourTimeLabel;
    [SerializeField] GameObject bestScoreLabel;
    [SerializeField] GameObject bestTimeLabel;

    [SerializeField] GameObject similarityLabel;

    [SerializeField] GameObject newHighScore;
    [SerializeField] GameObject newBestTime;

    [SerializeField] GameObject p1Camera;
    [SerializeField] GameObject p2Camera;

    [SerializeField] GameObject p1Screen;
    [SerializeField] GameObject p2Screen;
    [SerializeField] GameObject endScreen;

    

    private float highScore;
    private float bestTime;

    private float similarity;
    private float highSimilarity;

    private bool zoomOut;

    private void FixedUpdate()
    {
        if (zoomOut)
        {

            /* if (p1Camera.GetComponent<Camera>().orthographicSize < 50)
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
             }*/
            if (!endScreen.activeInHierarchy)
            {
                endScreen.SetActive(true);
            }
            

            if (p1Camera.transform.position.y < gameObject.GetComponent<BackgroundMove>().EndOfCameraMove())
            {
                p1Camera.transform.position += new Vector3(0, 0.1f, 0);
            }

            
        }

    }
    public void UpdateScores()
    {
        similarity = (1 - Mathf.Abs(Mathf.Abs(p1Camera.transform.position.y) - Mathf.Abs(p2Camera.transform.position.y)) / ((Mathf.Abs(p1Camera.transform.position.y) + Mathf.Abs(p2Camera.transform.position.y) + 1))) * 100;
        

        if (PlayerPrefs.HasKey("HighSimiliarity"))
        {
            highSimilarity = PlayerPrefs.GetFloat("HighSimiliarity");
        }
        
        if (highSimilarity < similarity)
        {
            highSimilarity = similarity;
            PlayerPrefs.SetFloat("HighSimiliarity", highSimilarity);
            newHighScore.SetActive(true);
        }

        winUI.SetActive(true);
        if (gameObject.GetComponent<PlayersMove>().playersDead)
        {
            uiLabel.GetComponent<TextMeshProUGUI>().text = "Perished Early";
        }
                
        yourScoreLabel.GetComponent<TextMeshProUGUI>().text = "Your Score Was: " + string.Format("{0:0.00}", similarity);
        bestScoreLabel.GetComponent<TextMeshProUGUI>().text = "Best Score Was: " + string.Format("{0:0.00}", highSimilarity);

        //similarityLabel.GetComponent<TextMeshProUGUI>().text = "Best Score was : " + highSimilarity.ToString("F0") + "%";

        /*
        yourTimeLabel.GetComponent<TextMeshProUGUI>().text = "Your Time Was: " + string.Format("{0:0.00}", time) + "Seconds";
        
        bestTimeLabel.GetComponent<TextMeshProUGUI>().text = "Best Time Was: " + string.Format("{0:0.00}", bestTime) + " Seconds";*/

        zoomOut = true;
    }


    public void UpdateScores(float score, float time)
    {
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

        //To Add time difference (0-1) with 1 most different - then enhance that by how far collectivly got
        //score = //Need to get distance 1 and distance 2

        yourScoreLabel.GetComponent<TextMeshProUGUI>().text = "Your Score Was: " + string.Format("{0:0.00}", score);
        yourTimeLabel.GetComponent<TextMeshProUGUI>().text = "Your Time Was: " + string.Format("{0:0.00}", time) + "Seconds";
        bestScoreLabel.GetComponent<TextMeshProUGUI>().text = "Best Score Was: " + string.Format("{0:0.00}", highScore);
        bestTimeLabel.GetComponent<TextMeshProUGUI>().text = "Best Time Was: " + string.Format("{0:0.00}", bestTime) + " Seconds";

        

        zoomOut = true;
    }

}
