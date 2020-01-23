using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private int kickCooldown = 41;

    private Animator animator;
    private PlayerMovement movementScript;

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
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.F)) && kickCooldown >= 40)
        {
            kickCooldown = 0;
        }
        if(kickCooldown < 40)
        {
            animator.SetBool("Kicking", true);
            movementScript.canMove = false;
        }
        else
        {
            animator.SetBool("Kicking", false);
            movementScript.canMove = true;
        }
    }
}
