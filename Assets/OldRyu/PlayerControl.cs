using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;
	public bool jump = false;
	public bool crouch = false;
	public bool hadouken = false;
	public float jumpForce = 400f;
	private Animator anim;					// Reference to the player's animator component.
	public float moveForce = 20f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 2f;	
	public BoxCollider2D head;
	public BoxCollider2D torso;
	public BoxCollider2D legs;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;

		if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow) && grounded)
			//if (Input.GetKeyDown (KeyCode.Space))
			crouch = true;
		if(Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow) && grounded)
			crouch = false;

		if(Input.GetKeyDown(KeyCode.P) && grounded)
			hadouken = true;
	}

	void FixedUpdate(){

		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("speed", Mathf.Abs(h));
		anim.SetFloat("speed", h);

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("jump");
			
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}

		if(crouch)
		{
			// Set the Jump animator trigger parameter.
			//anim.SetTrigger("crouch");
			anim.SetBool("crouch", true);
			//anim.SetTrigger(
			
			// Add a vertical force to the player.
			//rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			//jump = false;
		}
		else{
			anim.SetBool("crouch", false);
		}

		if(hadouken){
			anim.SetTrigger("hadouken");
			hadouken = false;
		}
	}
}
