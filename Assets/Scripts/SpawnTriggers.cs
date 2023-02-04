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
                        for(float k = 0; k <= resourcesTop.Length; k++)
                        {
                            if(val >= (k/resourcesTop.Length) && val <= (k+1/resourcesTop.Length))
                            {
                                inst = Instantiate(resourcesTop[(int)k], new Vector3(startPos.x+j,startPos.y+i, 100), Quaternion.Euler(90,0,180));
                                inst.transform.parent = resourcesPool.transform;
                            }
                        }
                    }
                    else if (val > 1f && val < 2f)//33% chance to spawn obstacle
                    {
                          for (float k = 0; k <= obstaclesTop.Length; k++)
                          {
                           if (val >= 1+(k / obstaclesTop.Length) && val <= 1+(k + 1 / obstaclesTop.Length))
                           {
                                inst = Instantiate(obstaclesTop[(int)k], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                inst.transform.parent = obstaclesPool.transform;
                            }
                        }
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
                        for (float k = 0; k <= resourcesBot.Length; k++)
                        {
                            if (val >= (k / resourcesBot.Length) && val <= (k + 1 / resourcesBot.Length))
                            {
                                randSize = Random.Range(0.05f,0.5f);
                                inst = Instantiate(resourcesBot[(int)k], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                inst.transform.localScale = new Vector3(randSize,randSize,randSize);
                                inst.transform.parent = resourcesPool.transform;
                            }
                        }
                    }
                    else if (val > 1f && val < 2f)//33% chance to spawn obstacle
                    {
                        for (float k = 0; k <= obstaclesBot.Length; k++)
                        {
                            if (val >= 1 + (k / obstaclesBot.Length) && val <= 1 + (k + 1 / obstaclesBot.Length))
                            {
                                randSize = Random.Range(0.05f, 0.5f);
                                inst = Instantiate(obstaclesBot[(int)k], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                inst.transform.localScale = new Vector3(randSize, randSize, randSize);
                                inst.transform.parent = obstaclesPool.transform;
                            }
                        }
                    }
                    else if (val > 2f && val < 3f)//33% chance to spawn obstacle
                    {
                        for (float k = 0; k <= backgroundBot.Length; k++)
                        {
                            if (val >= 2f + (k / backgroundBot.Length) && val <= 2f + (k + 1 / backgroundBot.Length))
                            {
                                randSize = Random.Range(0.05f, 0.5f);
                                inst = Instantiate(backgroundBot[(int)(k)], new Vector3(startPos.x + j, startPos.y + i, 100), Quaternion.Euler(90, 0, 180));
                                inst.transform.localScale = new Vector3(randSize, randSize, randSize);
                                inst.transform.parent = backgroundPool.transform;
                            }
                        }
                    }
                }

            }
        }
    }
}
