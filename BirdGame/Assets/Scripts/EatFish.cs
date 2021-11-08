using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour {

    private Vector2 trashPos;
    public bool noFish;
    public AudioClip eatSound;
    public AudioClip trashSound;
    private AudioSource soundEffect;
    
    private void Start()
    {
        soundEffect = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        noFish = true;
        trashPos = GameObject.FindGameObjectWithTag("Trash").transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag.Equals("Fish"))
        {
            if(noFish)
            {
                Destroy(other.transform.gameObject);
                this.GetComponent<Hunger>().eat();
                noFish = false;
                soundEffect.clip = eatSound;
                soundEffect.Play();
            }
        }
        if(other.transform.tag.Equals("Trash"))
        {
            Vector2 newPos = new Vector2();
            newPos = trashPos;
            other.transform.position = newPos;
            other.GetComponent<TrashMove>().stopMoving();
            this.GetComponent<Hunger>().eatTrash();
            soundEffect.clip = trashSound;
            soundEffect.Play();
        }
    }
}
