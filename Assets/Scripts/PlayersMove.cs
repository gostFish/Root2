using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMove : MonoBehaviour
{

    public float vertP1Speed;    //Effected by the points gather ed by the other player
    public float vertP2Speed;

    public bool isP1Done;    
    public bool isP2Done;

    [SerializeField] private float p1Speed;
    [SerializeField] private float p2Speed;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;

    [SerializeField] private float player1AccL;
    [SerializeField] private float player1AccR;

    [SerializeField] private float player2Acc;

    public bool playersDead;
   

    private void FixedUpdate()
    {
        if (!isP1Done) 
        {
            player1.transform.position -= new Vector3(0, vertP1Speed * Time.deltaTime, 0);
        }
        if (!isP2Done)
        {
            player2.transform.position += new Vector3(0, vertP2Speed * Time.deltaTime, 0);
        }            

        cam1.transform.position = new Vector3(0,player1.transform.position.y,0);
        cam2.transform.position = new Vector3(0, player2.transform.position.y, 0);

    }
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.A) && player1.transform.position.x > -4.5f)
        {
            //player1AccL += Time.deltaTime;
            player1.transform.position = player1.transform.position + new Vector3(-p1Speed * Time.deltaTime /** (player1AccL / (player1AccR + 0.01f))*/, 0,0);
            
        }
        /*else
        {
            if (player1AccL > 0)
            {
                player1AccL -= Time.deltaTime;
            }

        }*/

        if(vertP1Speed <= 0.25 || vertP2Speed <= 0.25)
        {
            playersDead = true;
        }

        if (Input.GetKey(KeyCode.D) && player1.transform.position.x < 4.5f)
        {
            //player1AccR += Time.deltaTime;
            player1.transform.position = player1.transform.position + new Vector3(p1Speed * Time.deltaTime /** (player1AccR/(player1AccL+0.01f))*/, 0, 0);
            
        }
       /* else
        {
            if(player1AccR > 0)
            {
                player1AccR -= Time.deltaTime;
            }
            
        }*/



        
        if (Input.GetKey(KeyCode.LeftArrow) && player2.transform.position.x > -4.5f)
        {
            player2.transform.position = player2.transform.position + new Vector3(-p2Speed * Time.deltaTime, 0, 0);
        }
       
        if (Input.GetKey(KeyCode.RightArrow) && player2.transform.position.x < 4.5f)
        {
            player2.transform.position = player2.transform.position + new Vector3(p2Speed * Time.deltaTime, 0, 0);
        }
    }
}
