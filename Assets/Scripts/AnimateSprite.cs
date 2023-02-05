using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSprite : MonoBehaviour
{

    
    [SerializeField]private Material[] frames;

    private float time;
    private int currFrame;

    public bool keepFinished;

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 0.2f)
        {
            time = 0;
            gameObject.transform.GetComponent<MeshRenderer>().material = frames[currFrame];
            currFrame++;
            if (currFrame >= frames.Length)
            {                
                if (!keepFinished)
                {
                    currFrame = 0;
                }
                else
                {
                    currFrame = frames.Length - 1;
                }
            }
            
        }
        
    }
}
