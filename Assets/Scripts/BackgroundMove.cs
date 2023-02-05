using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
{

    private float time;

    [SerializeField] private GameObject p1BackgoundPool;
    [SerializeField] private GameObject p2BackgoundPool;

    [SerializeField] private GameObject backgroundTile;
    private GameObject tileInst;


    [SerializeField] private Texture startTop;
    [SerializeField] private Texture middleTop;
    [SerializeField] private Texture endTop;

    [SerializeField] private Texture startBot;
    [SerializeField] private Texture middleBot;
    [SerializeField] private Texture endBot;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;


    [SerializeField] private float currHeight1;
    [SerializeField] private float currHeight2;

    [SerializeField] private float maxDist;

    private Material startMatTop;
    private Material middleMatTop;
    private Material endMatTop;

    private Material startMatBot;
    private Material middleMatBot;
    private Material endMatBot;

    private float score;
    private float backgroundScale;
    private bool showingStats;

    private void Awake()
    {
        backgroundScale = 10;
        startMatTop = new Material(Shader.Find("Diffuse"));
        middleMatTop = new Material(Shader.Find("Diffuse"));
        endMatTop = new Material(Shader.Find("Diffuse"));

        startMatBot = new Material(Shader.Find("Diffuse"));
        middleMatBot = new Material(Shader.Find("Diffuse"));
        endMatBot = new Material(Shader.Find("Diffuse"));

        startMatTop.mainTexture = startTop;
        middleMatTop.mainTexture = middleTop;
        endMatTop.mainTexture = endTop;

        startMatBot.mainTexture = startBot;
        middleMatBot.mainTexture = middleBot;
        endMatBot.mainTexture = endBot;

    }

    private void Start()
    {
        currHeight1 = player1.transform.position.y;
        tileInst = Instantiate(backgroundTile, new Vector3(0, -backgroundScale/2, 150), Quaternion.Euler(90, 0, 180));
        tileInst.GetComponent<MeshRenderer>().material = startMatBot;
        tileInst.transform.parent = p1BackgoundPool.transform;

        currHeight2 = player2.transform.position.y;
        tileInst = Instantiate(backgroundTile, new Vector3(0, backgroundScale/2, 150), Quaternion.Euler(90, 0, 180));
        tileInst.GetComponent<MeshRenderer>().material = startMatTop;
        tileInst.transform.parent = p2BackgoundPool.transform;


    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }

    void ExtraBackground()
    {
        //Spawn extra tiles for Top
        for (int i = 0; i < maxDist / (backgroundScale); i++)
        {

            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * i, backgroundScale/2, 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = startMatTop;
            tileInst.transform.parent = p2BackgoundPool.transform;

            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * -i, backgroundScale/2, 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = startMatTop;
            tileInst.transform.parent = p2BackgoundPool.transform;
            for (int j = 1; j< maxDist / (backgroundScale); j++)
            {
                
                    tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * i, (backgroundScale * j) + (backgroundScale / 2), 150), Quaternion.Euler(90, 0, 180));
                    tileInst.GetComponent<MeshRenderer>().material = middleMatTop;
                    tileInst.transform.parent = p2BackgoundPool.transform;

                    tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * -i, (backgroundScale * j) + (backgroundScale / 2), 150), Quaternion.Euler(90, 0, 180));
                    tileInst.GetComponent<MeshRenderer>().material = middleMatTop;
                    tileInst.transform.parent = p2BackgoundPool.transform;
                              
            }
            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * i, maxDist + ((backgroundScale) / 2), 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = endMatTop;
            tileInst.transform.parent = p2BackgoundPool.transform;

            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * -i, maxDist + ((backgroundScale) / 2), 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = endMatTop;
            tileInst.transform.parent = p2BackgoundPool.transform;
        }

        //Spawn extra tiles for bottom
        for (int i = 0; i < maxDist / (backgroundScale); i++)
        {

            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * i, -backgroundScale / 2, 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = startMatBot;
            tileInst.transform.parent = p2BackgoundPool.transform;

            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * -i, -backgroundScale / 2, 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = startMatBot;
            tileInst.transform.parent = p2BackgoundPool.transform;
            for (int j = 1; j < maxDist / (backgroundScale); j++)
            {
                
                    tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * i, (backgroundScale * -j) - (backgroundScale / 2), 150), Quaternion.Euler(90, 0, 180));
                    tileInst.GetComponent<MeshRenderer>().material = middleMatBot;
                    tileInst.transform.parent = p2BackgoundPool.transform;

                    tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * -i, (backgroundScale * -j) - (backgroundScale / 2), 150), Quaternion.Euler(90, 0, 180));
                    tileInst.GetComponent<MeshRenderer>().material = middleMatBot;
                    tileInst.transform.parent = p2BackgoundPool.transform;
                
            }
            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * i, -maxDist + ((-backgroundScale) / 2), 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = endMatBot;
            tileInst.transform.parent = p2BackgoundPool.transform;

            tileInst = Instantiate(backgroundTile, new Vector3(backgroundScale * -i, -maxDist + ((-backgroundScale) / 2), 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = endMatBot;
            tileInst.transform.parent = p2BackgoundPool.transform;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(player2.transform.position.y > (currHeight2- backgroundScale) && currHeight2 < maxDist)
        {
            currHeight2 += backgroundScale; 
            tileInst = Instantiate(backgroundTile, new Vector3(0, currHeight2 - backgroundScale / 2, 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material= middleMatTop;
            tileInst.transform.parent = p2BackgoundPool.transform;

            gameObject.GetComponent<SpawnTriggers>().SpawnRandomTop(tileInst.transform.position, 9, 8);

            if (currHeight2 > maxDist - backgroundScale)
            {
                currHeight2 += backgroundScale;
                tileInst = Instantiate(backgroundTile, new Vector3(0, currHeight2 - backgroundScale / 2, 150), Quaternion.Euler(90, 0, 180));
                tileInst.GetComponent<MeshRenderer>().material = endMatTop;
                tileInst.transform.parent = p2BackgoundPool.transform;
                gameObject.GetComponent<SpawnTriggers>().SpawnRandomTop(tileInst.transform.position, 9, 8);
            }
        }

        
        if (player1.transform.position.y < (currHeight1+ backgroundScale) && currHeight1 > -maxDist)
        {
            currHeight1 -= backgroundScale; 
            tileInst = Instantiate(backgroundTile, new Vector3(0, currHeight1 + backgroundScale / 2, 150), Quaternion.Euler(90, 0, 180));
            tileInst.GetComponent<MeshRenderer>().material = middleMatBot;
            tileInst.transform.parent = p1BackgoundPool.transform;

            gameObject.GetComponent<SpawnTriggers>().SpawnRandomBottom(tileInst.transform.position,9,8);

            if(currHeight1 < -maxDist + backgroundScale)
            {
                currHeight1 -= backgroundScale; 
                tileInst = Instantiate(backgroundTile, new Vector3(0, currHeight1 + backgroundScale / 2, 150), Quaternion.Euler(90, 0, 180));
                tileInst.GetComponent<MeshRenderer>().material = endMatBot;
                tileInst.transform.parent = p1BackgoundPool.transform;
                gameObject.GetComponent<SpawnTriggers>().SpawnRandomBottom(tileInst.transform.position, 9, 8);
            }
        }

        if(player1.transform.position.y <= -(maxDist-(backgroundScale/2)))
        {
            gameObject.GetComponent<PlayersMove>().isP1Done = true;
        }

        if (player2.transform.position.y >= (maxDist - (backgroundScale/2)))
        {
            gameObject.GetComponent<PlayersMove>().isP2Done = true;
        }

        if(gameObject.GetComponent<PlayersMove>().isP1Done && gameObject.GetComponent<PlayersMove>().isP2Done)
        {
            if (!showingStats)
            {

                score = Mathf.Abs(player1.transform.position.y) + Mathf.Abs(player2.transform.position.y);

                gameObject.GetComponent<Scores>().UpdateScores();
                //gameObject.GetComponent<Scores>().UpdateScores(score, time);
                //ExtraBackground();
                showingStats = true;
            }
        }

    }

    public float EndOfCameraMove()
    {
        return (player2.transform.position.y);
        //return (maxDist - (backgroundScale / 2));
    }
}
