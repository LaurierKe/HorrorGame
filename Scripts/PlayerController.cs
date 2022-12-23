using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerController.cs:
 * - This is used to control the player
 * - Inherits from Humanoid class
 */
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CircleCollider2D))]

public class PlayerController : Humanoid, IKillable
{
    private enum Direction { UP, DOWN, RIGHT, LEFT };

    [SerializeField]
    int healthPoints = 10;

    [SerializeField]
    string playerName;

    [SerializeField]
    float playerSpeed;

    private Rigidbody2D      rb;
    private Animator         anim;
    private CircleCollider2D circCollider;


    private Vector2 movementVector;
    void Awake()
    {
        healthPoints = health_points;
        playerName  =  human_name;
        playerSpeed =  walk_speed;
        can_be_killed = true;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        circCollider = GetComponent<CircleCollider2D>();
    }
    private void FixedUpdate()
    {
        MoveToDirection();
        Move();
    }
    protected override void Move()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        rb.velocity = movementVector.normalized * playerSpeed;
    }
    private void MoveToDirection()
    {
        if(movementVector.x > 0){
            anim.SetInteger("Direction", 3);
        }else if(movementVector.x < 0){
            anim.SetInteger("Direction", 2);
        }else if(movementVector.y > 0){
            anim.SetInteger("Direction", 0);
        }else if(movementVector.y < 0){
            anim.SetInteger("Direction", 1);
        }else{
            anim.SetInteger("Direction", -1);
        }
    }
    public void Kill()
    {
        // Instantiate particles
    }

    public int DealDamage(int amount)
    {
        if ((healthPoints - amount) > 0)
        {
            healthPoints -= amount;
        }
        else
        {
            Kill();
        }
        return healthPoints;
    }
}
