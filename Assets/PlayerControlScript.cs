using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {


	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public bool grounded = false;
	public bool left = false;
	public bool right = false;
	public bool jump = false;
	public bool crouch = false;


	public bool lp = false;
	public bool mp = false;
	public bool hp = false;
	public bool lk = false;
	public bool mk = false;
	public bool hk = false;

	// Use this for initialization
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

		//Movement
		if(Input.GetKeyDown(KeyCode.A) && grounded && !crouch)
			left = true;
		if(Input.GetKeyDown(KeyCode.D) && grounded && !crouch)
			right = true;
		if(Input.GetKeyUp(KeyCode.A) && grounded)
			left = false;
		if(Input.GetKeyUp(KeyCode.D) && grounded)
			right = false;

		if(Input.GetKeyDown(KeyCode.S) && grounded)
			crouch = true;
		if(Input.GetKeyUp(KeyCode.S) && grounded)
			crouch = false;
		if(Input.GetKeyDown(KeyCode.W) && grounded)
			jump = true;
		//Punches
		if(Input.GetKeyDown(KeyCode.Y) && grounded)
			lp = true;
		if(Input.GetKeyDown(KeyCode.U) && grounded)
			mp = true;
		if(Input.GetKeyDown(KeyCode.I) && grounded)
			hp = true;

		if(Input.GetKeyUp(KeyCode.Y) && grounded)
			lp = false;
		if(Input.GetKeyUp(KeyCode.U) && grounded)
			mp = false;
		if(Input.GetKeyUp(KeyCode.I) && grounded)
			hp = false;

		//Kicks
		if(Input.GetKeyDown(KeyCode.H) && grounded)	
			lk = true;
		if(Input.GetKeyDown(KeyCode.J) && grounded)
			mk = true;		
		if(Input.GetKeyDown(KeyCode.K) && grounded)
			hk = true;	

		if(Input.GetKeyUp(KeyCode.H) && grounded)	
			lk = false;
		if(Input.GetKeyUp(KeyCode.J) && grounded)
			mk = false;		
		if(Input.GetKeyUp(KeyCode.K) && grounded)
			hk = false;	
		/*if(Input.GetKeyDown(KeyCode.F))
		{Flip (); Debug.Log("Flip");}*/
	}

	void FixedUpdate(){
		
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("speed", Mathf.Abs(h));
		//anim.SetFloat("speed", h);
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		/*if(h * rigidbody2D.velocity.x < maxSpeed && !crouch && grounded)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
*/

		/*if(jump && rigidbody2D.velocity.x>0)
		{
			rigidbody2D.AddForce(new Vector2(10f, jumpForce));

		}*/

	}



}
