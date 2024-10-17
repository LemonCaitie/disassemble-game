using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_projectile : MonoBehaviour
{
    private GameObject gameObj;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = this.gameObject;
        rb = gameObj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity == Vector2.zero)
        {
            //add explosion animation?
            Destroy(gameObj);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "wall")
        {
            Destroy(gameObj);
        }
    }
}
