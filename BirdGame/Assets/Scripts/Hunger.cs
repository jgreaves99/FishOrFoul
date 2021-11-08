using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Hunger : MonoBehaviour
{
    private int hungerValue;
    public Text text;
    public Sprite hunderSprite;
    public Sprite eatSprite;
    private Sprite currentSprite;
    private float surviveTimeStart;
    private float surviveTimeEnd;
    private float surviveTime;
    private float hungerTimer;
    // Start is called before the first frame update
    void Start()
    {
        hungerTimer = 5f;
        hungerValue = 100;
        surviveTimeStart = Time.deltaTime;
        currentSprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (hungerValue < 50)
        {
            this.GetComponent<SpriteRenderer>().sprite = hunderSprite;
        }
        else if(this.GetComponent<SpriteRenderer>().sprite != eatSprite)
        {
            this.GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
        hungerTimer -= Time.deltaTime;
        if(hungerTimer <= 0)
        {
            hungerValue -= 10;
            if(hungerValue <= 0)
            {
                surviveTimeEnd = Time.deltaTime;
                surviveTime = surviveTimeEnd - surviveTimeStart;
                SceneManager.LoadScene(2);
            }
            hungerTimer = 5f;
            this.GetComponent<SpriteRenderer>().sprite = currentSprite;
            text.text = "Hunger: " + hungerValue;
        }
    }
    public int getHunger()
    {
        return hungerValue;
    }
    public void eat()
    {
        if (hungerValue < 100)
        {
            hungerValue += 10;
            text.text = "Hunger: " + hungerValue;
        }
        else
        {
            hungerTimer = 5f;
        }
        this.GetComponent<SpriteRenderer>().sprite = eatSprite;
    }
    public void eatTrash()
    {
        hungerValue -= 20;
        if (hungerValue <= 0)
        {
            surviveTimeEnd = Time.deltaTime;
            surviveTime = surviveTimeEnd - surviveTimeStart;
            SceneManager.LoadScene(2);
        }
        text.text = "Hunger: " + hungerValue;
    }
}
