using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {

    public float move;
    private Rigidbody2D rigid;
    private Vector2 starting;
    private Vector2 start;
    private Vector2 end;
    private bool reachedPoint;
    private float count;
    float stopTimer;

    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        starting = rigid.position;
        start.y = rigid.position.y;
        start.x = rigid.position.x;
        end.y = rigid.position.y + 8;
        end.x = rigid.position.x + 4;
        reachedPoint = false;
        count = 0.0f;
        stopTimer = 0.5f;
    }
    // Update is called once per frame
    void Update ()
    {
        if(! reachedPoint)
        {
            count += 1.0f * Time.deltaTime;
            rigid.position = Vector3.Lerp(start, end, count);
        }
       

        if(rigid.position == end)
        {
            if(reachedPoint == true)
            {
                this.transform.position = starting;
                start.x = starting.x;
                start.y = starting.y;
                end.y = starting.y + 8;
                end.x = starting.x + 4;
                reachedPoint = false;
                count = 0.0f;
            }
            else
            {
                if(stopTimer <= 0)
                {
                    start.y = rigid.position.y;
                    start.x = rigid.position.x;
                    reachedPoint = true;
                    end.y = rigid.position.y - 8;
                    end.x = rigid.position.x + 4;
                    count = 0.0f;
                    stopTimer = 0.5f;
                }
                stopTimer -= Time.deltaTime;
            }
        }

        if(reachedPoint)
        {
            count += 1.0f * Time.deltaTime;
            rigid.position = Vector3.Lerp(start, end, count);
        }
        /*if (!reachedPoint)
        {
            
           rigid.velocity = new Vector2(rigid.velocity.x, move); 
        }
        else if (reachedPoint)
        {
           rigid.velocity = new Vector2(rigid.velocity.x, move * -1);
        }

        if (rigid.position.y >= end)
        {
            reachedPoint = true;
        }
        else if (rigid.position.y < start)
        {
            reachedPoint = false;
        }*/
    }
}
