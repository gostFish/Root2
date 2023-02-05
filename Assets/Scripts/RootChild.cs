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

    public bool player1;

    // Update is called once per frame

    private void Start()
    {
        //player1 = GameObject.FindGameObjectWithTag("Player1");
        m_Rigidbody = GetComponent<Rigidbody>();
        transform.rotation = moveDir;
    }
    void FixedUpdate()
    {
        if (depth > 0 && !GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayersMove>().isP1Done)
        {
            time = time + Time.deltaTime;
            
            if (time > 2)
            {
                if(Random.Range(0f,10f) < 3f)
                {
                    if (!player1)
                        m_Rigidbody.velocity = transform.right * speed;

                    inst = Instantiate(rootChild, transform.position, Quaternion.identity);
                    float randx = Random.Range(-10f, 10f);
                    float randy = Random.Range(-10f, 10f);
                    inst.GetComponent<RootChild>().moveDir = Quaternion.Euler(0, moveDir.x + randx, moveDir.y + randy);
                    //inst.GetComponent<RootChild>().moveDir = Quaternion.Euler(moveDir.x + randx, moveDir.y + randy, 0);
                    inst.GetComponent<RootChild>().depth = depth - 1;
                    //inst.transform.parent = gameObject.transform;
                }
                if (Random.Range(0f, 10f) < 3f)
                {
                    if (!player1)
                        m_Rigidbody.velocity = -transform.right * speed;

                    inst = Instantiate(rootChild, transform.position, Quaternion.identity);
                    float randx = Random.Range(-10f, 10f);
                    float randy = Random.Range(-10f, 10f);
                    inst.GetComponent<RootChild>().moveDir = Quaternion.Euler(0, moveDir.x - randx, moveDir.y - randy);
                    //inst.GetComponent<RootChild>().moveDir = Quaternion.Euler(moveDir.x - randx, moveDir.y - randy, 0);
                    inst.GetComponent<RootChild>().depth = depth - 1;
                    //inst.transform.parent = gameObject.transform;
                }


                time = 0;
            }

        }
        else if(GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayersMove>().isP1Done)
        {
            m_Rigidbody.velocity = new Vector3(0,0,0);
        }
     }
  
}
