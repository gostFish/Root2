using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootChild : MonoBehaviour
{
    [SerializeField] private GameObject rootChild;
    [SerializeField] private float speed;

    private float time;
    public float angle1;
    public float angle2;

    public Quaternion moveDir;

    public float depth;
    public bool stop;


    private float val;

    private Rigidbody m_Rigidbody;
    private GameObject inst;

    public GameObject player1;

    // Update is called once per frame

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        m_Rigidbody = GetComponent<Rigidbody>();
        transform.rotation = moveDir;
    }
    void FixedUpdate()
    {

        if (depth > 0 && !gameObject.GetComponent<PlayersMove>().isP1Done)
        {
            time = time + Time.deltaTime;
            if (time > 2)
            {
                if(transform.position.y <  player1.transform.position.y)
                {
                    m_Rigidbody.velocity = transform.forward * speed;
                }
                
                if(Random.Range(0f,10f) < 3f)
                {
                    inst = Instantiate(rootChild, transform.position, Quaternion.identity);
                    inst.GetComponent<RootChild>().moveDir = Quaternion.Euler(0, moveDir.x + 30, moveDir.y + 30);
                    inst.GetComponent<RootChild>().depth = depth - 1;
                    //inst.transform.parent = gameObject.transform;
                }
                if (Random.Range(0f, 10f) < 3f)
                {
                    inst = Instantiate(rootChild, transform.position, Quaternion.identity);
                    inst.GetComponent<RootChild>().moveDir = Quaternion.Euler(0, moveDir.x - 30, moveDir.y - 30);
                    inst.GetComponent<RootChild>().depth = depth - 1;
                    //inst.transform.parent = gameObject.transform;
                }


                time = 0;
            }
                
         }
     }
  
}
