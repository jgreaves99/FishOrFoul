using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public float move;
    private Rigidbody2D rigid;
    public GameObject body;
    private Rigidbody2D bodyRigid;
    private Vector2 start;
    private bool moving;
    private float startx;
    private Vector2 mousePos;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        bodyRigid = body.GetComponent<Rigidbody2D>();
        start = rigid.position;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            rigid.position = Vector2.MoveTowards(rigid.position, mousePos, move * Time.deltaTime);
            if (rigid.position == mousePos )
            {
                moving = false;
            }
        }
        else
        {
            rigid.position = Vector2.MoveTowards(rigid.position, start, move * Time.deltaTime);
            if(rigid.position == start)
            {
                this.GetComponent<EatFish>().noFish = true;
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    mousePos = ray.origin;
                    if(ray.origin.x > start.x)
                        moving = true;
                }
            }
        }
        /*if (rigid.position.y >= bodyRigid.position.y && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, move * -1);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || rigid.position.y < bodyRigid.position.y)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.position = new Vector2(rigid.position.x, rigid.position.y + 0.01f);
        }
        if (rigid.position.y <= start && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, move);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || rigid.position.y > start)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.position = new Vector2(rigid.position.x, rigid.position.y - 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(move, rigid.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigid.velocity = new Vector2(move * -1, rigid.velocity.y);
        }
        if (rigid.position.x < startx)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            rigid.position = new Vector2(rigid.position.x + 0.1f, rigid.position.y);
        } */

    }
}
