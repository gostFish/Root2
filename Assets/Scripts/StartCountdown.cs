using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{

    [SerializeField] private GameObject ready;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject banner;

    [SerializeField] private GameObject timerLabel;

    public float timer;
    private bool showingStats;

    IEnumerator WaitForRealSeconds(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < seconds)
        {
            yield return null;
        }
    }

    IEnumerator CountDownPt()
    {
        Time.timeScale = 0;
        ready.SetActive(true);
        start.SetActive(false);
        timerLabel.SetActive(false);


        yield return StartCoroutine(WaitForRealSeconds(2f));
        ready.SetActive(false);
        start.SetActive(true);
        yield return StartCoroutine(WaitForRealSeconds(1f));
        start.SetActive(false);
        Time.timeScale = 1;
        timerLabel.SetActive(true);
        banner.SetActive(false);
    }

   

    // Start is called before the first frame update
    void Start()
    {
        banner.SetActive(true);
        StartCoroutine(CountDownPt());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        timerLabel.GetComponent<TextMeshProUGUI>().text = "" + timer.ToString("F0");
        if(timer <= 0)
        {
            if(!showingStats){
                gameObject.GetComponent<PlayersMove>().isP1Done = true;
                gameObject.GetComponent<PlayersMove>().isP2Done = true;
                GameObject.FindGameObjectWithTag("Player2").GetComponent<AnimateSprite>().enabled = true;
                timerLabel.SetActive(false);
                //gameObject.GetComponent<Scores>().UpdateScores();
                showingStats = true;
            }
            
            //ExtraBackground();
            //showingStats = true;
        }
    }
}
