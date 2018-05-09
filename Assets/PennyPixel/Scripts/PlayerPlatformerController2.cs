using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlatformerController2 : PhysicsObject {

	public Text scoreT;

	public int score = 0;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

	public bool active = true;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake () 
    {
		scoreT.text = "Player 2: " + score;
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
    }

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Gem")) {
			score++;
			scoreT.text = "Player 2: " + score;
		}
		if (theCollider.CompareTag ("SpecialGem")) {
			score+=3;
			scoreT.text = "Player 1: " + score;
		}
	}

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("HorizontalArrow");

		if (Input.GetKeyDown(KeyCode.Return) && grounded) {
            velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetKeyDown(KeyCode.Return)) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x > 0.01f)
        {
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        else if (move.x < -0.01f)
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
	public int getScore(){
		return score;
	}
	public void setScore(int score){
		this.score = score;
	}
	public void setActive(bool a){
		active = a;
	}
}