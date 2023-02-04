using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{

    [SerializeField] private GameObject ready;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject banner;

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

        
        yield return StartCoroutine(WaitForRealSeconds(2f));
        ready.SetActive(false);
        start.SetActive(true);
        yield return StartCoroutine(WaitForRealSeconds(1f));
        start.SetActive(false);
        Time.timeScale = 1;

    }

   

    // Start is called before the first frame update
    void Start()
    {
        banner.SetActive(true);
        StartCoroutine(CountDownPt());
        banner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
