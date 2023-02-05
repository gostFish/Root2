using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    [SerializeField] private bool isPlayer1;

    private GameObject gameManager;
    public bool stopRoots;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<PlayersMove>().isP1Done)
        {
            stopRoots = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer1)
        {
            
            switch (other.tag)
            {
                case ("Resource"):
                    gameManager.GetComponent<PlayersMove>().vertP2Speed += Random.Range(0.15f,0.55f);
                    break;
                case ("Obstacle"):
                    if (gameManager.GetComponent<PlayersMove>().vertP1Speed > 0)
                    {
                        gameManager.GetComponent<PlayersMove>().vertP1Speed -= Random.Range(0.15f, 0.45f);
                        
                    }

                    /*if (gameManager.GetComponent<PlayersMove>().vertP2Speed > 0)
                    {
                        gameManager.GetComponent<PlayersMove>().vertP2Speed -= 0.15f;
                    }*/

                        break;
            }
                
        }
        if (!isPlayer1)
        {
            switch (other.tag)
            {
                case ("Resource"):
                    gameManager.GetComponent<PlayersMove>().vertP1Speed += Random.Range(0.15f, 0.55f);
                    break;
                case ("Obstacle"):
                    /*if(gameManager.GetComponent<PlayersMove>().vertP1Speed > 0)
                    {
                        gameManager.GetComponent<PlayersMove>().vertP1Speed -= Random.Range(0.1f, 0.2f);
                    }*/
                    if (gameManager.GetComponent<PlayersMove>().vertP2Speed > 0)
                    {
                        gameManager.GetComponent<PlayersMove>().vertP2Speed -= Random.Range(0.15f, 0.45f);
                    }
                        
                    break;
            }
        }
        Destroy(other.gameObject);
    }
}
