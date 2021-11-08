using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{

    public float move;
    private Rigidbody2D rigid;
    private float start;
    private float end;
    private bool reachedPoint;
    private bool moving;
   
    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        start = rigid.position.y;
        end = rigid.position.y + 6;
        reachedPoint = false;
        rigid.Sleep();
        rigid.isKinematic = true;
        moving = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            rigid.AddForce(new Vector2(-100 * move, 0));
            moving = false;
            /*print("hi");
            if (!reachedPoint)
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("Water"))
        {
            this.stopMoving();
        }
    }
    public void startMoving()
    {
        moving = true;
        rigid.WakeUp();
        rigid.isKinematic = false;
    }
    public void stopMoving()
    {
        rigid.Sleep();
        rigid.isKinematic = true;
        moving = false;
    }
}
