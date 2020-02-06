using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private int kickCooldown = 41;
    private int throwCooldown = 35;

    private Animator animator;
    private PlayerMovement movementScript;

    [SerializeField] private float bibleSpeed = 9;

    [SerializeField] GameObject Bible;
    [SerializeField] GameObject BibleStart;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        kickCooldown++;
        throwCooldown++;
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.F)) && kickCooldown >= 40 && throwCooldown >= 20)
        {
            kickCooldown = 0;
        }
        if(kickCooldown < 40)
        {
            animator.SetBool("Kicking", true);
            animator.SetBool("Jumping", false);
            movementScript.canMove = false;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            animator.SetBool("Kicking", false);
            movementScript.canMove = true;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G)) && throwCooldown >= 35 && kickCooldown >= 45){
            throwCooldown = 0;
            FireBible();
        }
        if(throwCooldown < 15)
        {
            movementScript.canMove = false;
            animator.SetBool("Throwing", true);
        }
        else if(kickCooldown>=40)
        {
            movementScript.canMove = true;
        }
        if(throwCooldown>=15)
        {
            animator.SetBool("Throwing", false);
        }
    }

    void FireBible()
    {
        GameObject b = Instantiate(Bible) as GameObject;
        b.transform.position = BibleStart.transform.position;
        b.GetComponent<Rigidbody2D>().velocity = new Vector2(bibleSpeed * movementScript.direction, 0);
        b.GetComponent<Rigidbody2D>().AddTorque(-20f * movementScript.direction);
    }
}
