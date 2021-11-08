using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCurtainLeft : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float move;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(move, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.position.x <= -20)
        {
            rigid.velocity = new Vector2(0, 0);
        }
    }
}
