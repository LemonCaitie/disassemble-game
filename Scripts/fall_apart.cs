using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_apart : MonoBehaviour
{

    public List<Sprite> sprites;
    public SpriteRenderer character;

    private int count;

    public GameObject projectile;

    //audio stuff
    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        count = sprites.Count - 1;
    }

    // Update is called once per frame
    public void BreakApart(Vector2 shootVel)
    {
        if (count >= 0) //Input.GetKeyDown(KeyCode.Space) && 
        {
            character.sprite = sprites[count];
            shootSound.Play();
            GameObject brokenPart = Instantiate(projectile, new Vector3(0, 1.1f, 0), Quaternion.identity);
            Rigidbody2D rb = brokenPart.GetComponent<Rigidbody2D>();
            rb.velocity = shootVel; //new Vector2(1,3);
            //randomise the torque?
            rb.AddTorque(50);

            count -= 1;
        }
    }

    public void Reload()
    {
        count = sprites.Count - 1;
    }

    public int getCount()
    {
        return count;
    }
}
