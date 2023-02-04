using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootChild : MonoBehaviour
{
    [SerializeField] private GameObject rootChild;
    [SerializeField] private float speed;

    private float time;
    public float angle;
    public float depth;
    public bool stop;


    private float val;
    public bool jitter;

    private Rigidbody m_Rigidbody;
    private GameObject inst;

    public GameObject player1;

    // Update is called once per frame

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        m_Rigidbody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(angle, angle, 0);
    }
    void FixedUpdate()
    {

        if (depth > 0)
        {
            time = time + Time.deltaTime;
            if (time > 0.2f)
            {
                if(transform.position.y >  player1.transform.position.y)
                {
                    m_Rigidbody.velocity = transform.forward * speed;
                }                
                

                if (depth > 0 && angle > 90 && angle < 270) //Dont spawn upwards
                {
                    val = Random.Range(0f, 10f);
                    if (val < 0.7f)
                    {

                        inst = Instantiate(rootChild, transform.position, Quaternion.identity);
                        inst.GetComponent<RootChild>().angle = angle / 3;
                        inst.GetComponent<RootChild>().depth = depth - 1;
                        inst.transform.parent = gameObject.transform;
                    }
                    else if (val < 1f)
                    {
                        inst = Instantiate(rootChild, transform.position, Quaternion.identity);
                        inst.GetComponent<RootChild>().angle = -angle/3;
                        inst.GetComponent<RootChild>().depth = depth - 1;
                        inst.transform.parent = gameObject.transform;
                    }
                }
                time = 0;
            }
        }
    }
        
        
        

    
}
