using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_robot : MonoBehaviour
{

    public bool beingFixed;
    public GameObject character;
    public Sprite fixed_robot;
    public scoreCounter scorecount;
    public fall_apart projectiles;

    public Animator liftAnim;
    public Animator charaAnim;

    //audio stuff
    public AudioSource fixSound;

    // Start is called before the first frame update
    void Start()
    {
        beingFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !beingFixed && scorecount.score > 0)
        {
            beingFixed = true;
            scorecount.decreaseScore(1);
            StartCoroutine(moveCharacter());
        }
    }

    IEnumerator moveCharacter()
    {
        liftAnim.SetInteger("lift_stage", 1);
        charaAnim.SetInteger("character_fix", 1);
        /*while (character.transform.position != this.gameObject.transform.position)
        {
            character.transform.position = Vector2.MoveTowards(character.transform.position, this.gameObject.transform.position, 0.5f * Time.deltaTime);
        }*/
        fixSound.Play();
        yield return new WaitForSeconds(3.5f);
        character.GetComponent<SpriteRenderer>().sprite = fixed_robot;
        liftAnim.SetInteger("lift_stage", 2);
        charaAnim.SetInteger("character_fix", 2);
        /*while (character.transform.position != Vector3.zero)
        {
            character.transform.position = Vector2.MoveTowards(character.transform.position, Vector3.zero, 0.5f * Time.deltaTime);
        }*/
        yield return new WaitForSeconds(0.5f);
        beingFixed = false;
        liftAnim.SetInteger("lift_stage", 0);
        charaAnim.SetInteger("character_fix", 0);
        projectiles.Reload();
    }
}
