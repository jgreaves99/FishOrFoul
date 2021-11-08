using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject fish;
    public GameObject trash;
    private GameObject newFish;
    private float fishTimer;
    private Vector2 initialPos;
    private Vector2 trashPos;
    private Vector2 newPos;
    private float speedTimer;
    private float trashTimer;
    private float speedUp = 2;

    // Start is called before the first frame update
    void Start()
    {
        fishTimer = 5f;
        speedTimer = 30f;
        trashTimer = 10f;
        initialPos = GameObject.FindGameObjectWithTag("Fish").transform.position;
        trashPos = GameObject.FindGameObjectWithTag("Trash").transform.position;
        fish.GetComponent<FishMove>().move = 5;
        trash.GetComponent<TrashMove>().stopMoving();
    }

    // Update is called once per frame
    void Update()
    {
        fishTimer -= Time.deltaTime;
        speedTimer -= Time.deltaTime;
        trashTimer -= Time.deltaTime;

        if (fishTimer <= 0)
        {
            newFish = fish;
            newPos.y = initialPos.y;
            newPos.x = Random.Range(-3f, 8f);
            newFish.transform.position = newPos;
            if (speedTimer <= 0)
            {
                print("Speed up");
                newFish.GetComponent<FishMove>().move = 5 * speedUp;
                speedUp *= 2;
                speedTimer = 30f;
            }
            Instantiate(newFish);
            fishTimer = 5f;
        }
        if(trashTimer <= 0)
        {
            trash.GetComponent<Rigidbody2D>().position = trashPos;
            trash.GetComponent<TrashMove>().startMoving();
            trashTimer = 10f;
        } 

    }
}
