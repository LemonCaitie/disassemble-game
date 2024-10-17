using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_enemy : MonoBehaviour
{
    private GameObject gameObj;
    private Rigidbody2D rb;

    private scoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = this.gameObject;
        rb = gameObj.GetComponent<Rigidbody2D>();

        scoreCounter = GameObject.Find("Score").GetComponent<scoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "projectile")
        {
            scoreCounter.increaseScore(1);
            Destroy(gameObj);
        }
    }
}
