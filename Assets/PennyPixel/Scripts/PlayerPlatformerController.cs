using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlatformerController : PhysicsObject {

	public Text scoreT;

	public string playerName;
	public bool active = true;

	public int score = 0;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake () 
    {
		this.tag = playerName;
		scoreT.text = playerName + ": " + score;
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
    }

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Gem")) {
			score++;
			scoreT.text = playerName + ": " + score;
		}
		if (theCollider.CompareTag ("SpecialGem")) {
			score+=3;
			scoreT.text = playerName + ": " + score;
		}
	}
		
    protected override void ComputeVelocity()
    {
		if (active == true)
			return;
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("HorizontalLetter");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
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