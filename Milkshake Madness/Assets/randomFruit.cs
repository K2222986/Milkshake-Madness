using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomFruit : MonoBehaviour
{
    private int rand;
    public Sprite[] spriteImage;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, spriteImage.Length);
        GetComponent<SpriteRenderer>().sprite = spriteImage[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
