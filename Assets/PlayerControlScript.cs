using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {


	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public bool grounded = false;
	public bool jump = false;
	public bool crouch = false;
	public bool facingRight = true;
	public float jumpForce = 400f;
	public float moveForce = 20f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 2f;	
	// Use this for initialization
	public bool lp = false;
	public bool mp = false;
	public bool hp = false;
	public bool lk = false;
	public bool mk = false;
	public bool hk = false;

	void Start () {
	
	}

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
	}

	
	// Update is called once per frame
	void Update () {

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		if(Input.GetKeyDown(KeyCode.DownArrow) && grounded)
			crouch = true;
		if(Input.GetKeyUp(KeyCode.DownArrow) && grounded)
			crouch = false;
		if(Input.GetButtonDown("Jump")||Input.GetKeyUp(KeyCode.UpArrow) && grounded)
			jump = true;
		//Punches
		if(Input.GetKeyDown(KeyCode.Q) && grounded)
			lp = true;
		if(Input.GetKeyDown(KeyCode.W) && grounded)
			mp = true;
		if(Input.GetKeyDown(KeyCode.E) && grounded)
			hp = true;

		//Kicks
		if(Input.GetKeyDown(KeyCode.A) && grounded)	
			lk = true;
		if(Input.GetKeyDown(KeyCode.S) && grounded)
			mk = true;		
		if(Input.GetKeyDown(KeyCode.D) && grounded)
			hk = true;	
		if(Input.GetKeyDown(KeyCode.F))
		{Flip (); Debug.Log("Flip");}
	}

	void FixedUpdate(){
		
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("speed", Mathf.Abs(h));
		//anim.SetFloat("speed", h);
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed && !crouch && grounded)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			//jump = false;
		}
		/*if(jump && rigidbody2D.velocity.x>0)
		{
			rigidbody2D.AddForce(new Vector2(10f, jumpForce));

		}*/

	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
