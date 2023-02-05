using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggers : MonoBehaviour
{

    [SerializeField] private GameObject[] resourcesTop;
    [SerializeField] private GameObject[] obstaclesTop;
    [SerializeField] private GameObject[] backgroundTop;

    [SerializeField] private GameObject[] resourcesBot;
    [SerializeField] private GameObject[] obstaclesBot;
    [SerializeField] private GameObject[] backgroundBot;

    [SerializeField] private GameObject resourcesPool;
    [SerializeField] private GameObject obstaclesPool;
    [SerializeField] private GameObject backgroundPool;

    private float val;
    private GameObject inst;
    private float randSize;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomTop(Vector3 startPos,int height,int width)        
    {
        //Debug.Log("Called");
        for (float i = -height/2; i < height/2; i+=1.2f)
        {
            for (float j = -width/2; j < width/2; j+=1.2f)
            {
                val = Random.Range(0f, 20f);
                //Debug.Log(val);
                if (val < 4)// 2% chance to spawn something
                { 
                    if(val < 1f)//33 chance of new spawned thing to be Resource
                    {
                       // Debug.Log("Hey");
                                inst = Instantiate(resourcesTop[Random.Range(0,resourcesTop.Length)], new Vector3(startPos.x+j,startPos.y+i, 100), Quaternion.Euler(90,0,180));
                                inst.transform.parent = resourcesPool.transform;

                    }
                    else if (val > 1f && val < 2f)//33% chance to spawn obstacle
                    {

                                inst = Instantiate(obstaclesTop[Random.Range(0,obstaclesTop.Length)], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                inst.transform.parent = obstaclesPool.transform;

                    }
                    /*else if (val > 2f && val < 3f)//33% chance to spawn obstacle
                    {
                        for (float k = 0; k <= backgroundTop.Length; k++)
                        {
                            if (val >= 2f+(k / backgroundTop.Length) && val <= 2f+(k + 1 / backgroundTop.Length))
                            {
                                inst = Instantiate(backgroundTop[(int)(k)], new Vector3(startPos.x+ j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                inst.transform.parent = backgroundPool.transform;
                            }
                        }
                    }*/
                }

            }
        }
    }

    public void SpawnRandomBottom(Vector3 startPos, int height, int width)
    {
        //Debug.Log("Called");
        for (float i = -height / 2; i < height / 2; i += 1.2f)
        {
            for (float j = -width / 2; j < width / 2; j += 1.2f)
            {
                val = Random.Range(0f, 20f);
                //Debug.Log(val);
                if (val < 4)// 2% chance to spawn something
                {
                    if (val < 1f)//33 chance of new spawned thing to be Resource
                    {

                                randSize = Random.Range(0.05f,0.5f);
                                inst = Instantiate(resourcesBot[Random.Range(0,resourcesBot.Length)], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                //inst.transform.localScale = new Vector3(randSize,randSize,randSize);
                                inst.transform.parent = resourcesPool.transform;

                    }
                    else if (val > 1f && val < 2f)//33% chance to spawn obstacle
                    {

                                randSize = Random.Range(0.05f, 0.5f);
                                inst = Instantiate(obstaclesBot[Random.Range(0, obstaclesBot.Length)], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                //inst.transform.localScale = new Vector3(randSize, randSize, randSize);
                                inst.transform.parent = obstaclesPool.transform;

                    }
                    else if (val > 2f && val < 3f)//33% chance to spawn obstacle
                    {

                                randSize = Random.Range(0.05f, 0.5f);
                        if(backgroundBot.Length > 0) {
                            inst = Instantiate(backgroundBot[Random.Range(0, backgroundBot.Length)], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                            //inst.transform.localScale = new Vector3(randSize, randSize, randSize);
                            inst.transform.parent = backgroundPool.transform;
                        }
                                

                    }
                }

            }
        }
    }
}
