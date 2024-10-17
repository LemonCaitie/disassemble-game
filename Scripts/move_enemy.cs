using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_enemy : MonoBehaviour
{
    public int speed;
    public Vector2 direction;
    private Rigidbody2D rb;
    public bool moveY;
    public bool moveX;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        moveY = (Random.value > 0.5f);
        moveX = (Random.value > 0.5f);
        
        if (!moveX && !moveY)
        {
            bool fill = Random.value > 0.5f;
            if (fill)
            {
                moveX = true;
            }
            else
            {
                moveY = true;
            }
        }
        if(moveX && moveY)
        {
            speed /= 2;
        }

        if (moveX)
        {
            if (this.gameObject.transform.position.x >= 0)
            {
                direction.x -= 1;
            }
            if (this.gameObject.transform.position.x < 0)
            {
                direction.x += 1;
            }
        }
        if (moveY)
        {
            if (this.gameObject.transform.position.y >= 0)
            {
                direction.y -= 1;
            }
            if (this.gameObject.transform.position.y < 0)
            {
                direction.y += 1;
            }
        }

       //direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    { 
        rb.velocity = new Vector2((direction.x * speed), (direction.y * speed));

        //9.51 x  and  -7.74
        //4.08 y 
        if ((this.gameObject.transform.position.y > 5.40 || this.gameObject.transform.position.y < -5.71) || (this.gameObject.transform.position.x > 9.91 || this.gameObject.transform.position.x < -9.14))
        {
            Destroy(this.gameObject);
        }
    }
}
