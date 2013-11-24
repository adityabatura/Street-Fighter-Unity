using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour {

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public bool grounded;

	/*private bool facingRight;
	private float jumpForce;
	private float moveForce;			// Amount of force added to move the player left and right.
	private float maxSpeed;*/

	private bool jump = false;
	private bool crouch = false;
	private bool recovered;

	private bool lp = false;
	private bool mp = false;
	private bool hp = false;
	private bool lk = false;
	private bool mk = false;
	private bool hk = false;

	private bool right = false;
	private bool left = false;

	//Timers
	//private float jumpTimer;
	//private float moveTimer;


	private PlayerControlScript controller;

	private PlayerProperties properties;

	public AnimationScript anim;
	// Use this for initialization
	void Start () {

		controller = GetComponent <PlayerControlScript> ();
		anim = GetComponentInChildren<AnimationScript>();
		properties = GetComponent<PlayerProperties>();

		/*facingRight = properties.facingRight;
		jumpForce = properties.jumpForce;
		moveForce = properties.moveForce;			// Amount of force added to move the player left and right.
		maxSpeed = properties.maxSpeed;
		jumpTimer = properties.jumpTimer;
		float moveTimer = properties.moveTimer;*/
		
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
		
		//grounded = properties.grounded;
		recovered =  properties.recovered;

		
	}
	void FixedUpdate () {

	}

	public void Jump(){
		if(grounded && !crouch && recovered){
			if(properties.jumpTimer==0){
				if (rigidbody2D.velocity.x==0){
					rigidbody2D.AddForce(new Vector2(0.0f, properties.jumpForce));
				}else{
					if(rigidbody2D.velocity.x>0.1){
						rigidbody2D.AddForce(new Vector2(100f, properties.jumpForce));
					}else if(rigidbody2D.velocity.x<-0.1){
						rigidbody2D.AddForce(new Vector2(-100f, properties.jumpForce));
					}
				}
				anim.Jump();
				Debug.Log ("Jump");
				properties.jumpTimer = Time.time+1.5f;
			}else if(Time.time < properties.jumpTimer){
				Debug.Log ("Too Soon");
			}else if(Time.time > properties.jumpTimer){
				properties.jumpTimer = 0;	
			}
		}
	}



	public void Crouch(){
		if(grounded && recovered){
			crouch = true;
			anim.Crouch();
			Debug.Log ("Crouch");
		}
	}
	public void CrouchOff(){
		crouch = false;
		anim.CrouchOff();
		Debug.Log ("Crouch Off");
	}

	public void LP(){
		if(properties.moveTimer==0  && recovered){
			anim.LP();
			Debug.Log ("Low Punch");
			properties.moveTimer = Time.time+0.18f;
		}else if(Time.time < properties.moveTimer){
			Debug.Log ("Too Soon");
		}else if(Time.time >properties. moveTimer){

			properties.moveTimer = 0;

		}
	}
	public void MP(){
		Debug.Log ("Mid Punch");
	}
	public void HP(){
		Debug.Log ("High Punch");
	}
	public void LK(){
		if(properties.moveTimer==0  && recovered){
			anim.LK();
			Debug.Log ("Low Kick");
			properties.moveTimer = Time.time+0.5f;
		}else if(Time.time < properties.moveTimer){
			Debug.Log ("Too Soon");
		}else if(Time.time > properties.moveTimer){
			
			properties.moveTimer = 0;
			
		}
	}
	public void MK(){
		if(properties.moveTimer==0 && recovered){
			anim.LK();
			Debug.Log ("Mid Kick");
			properties.moveTimer = Time.time+0.5f;
		}else if(Time.time < properties.moveTimer){
			Debug.Log ("Too Soon");
		}else if(Time.time > properties.moveTimer){
			
			properties.moveTimer = 0;
			
		}
	}
	public void HK(){
		Debug.Log ("High Kick");
	}
	public void Right(){
		if(!crouch && !jump && properties.grounded  && recovered){
			rigidbody2D.AddForce(Vector2.right * 1 * properties.moveForce);
			Debug.Log ("Right");
		}
	}
	public void Left(){
		if(!crouch && !jump && grounded  && recovered){
			rigidbody2D.AddForce(Vector2.right * -1 * properties.moveForce);
			Debug.Log ("Left");
		}
	}

	public void Flip ()
	{
		// Switch the way the player is labelled as facing.
		properties.facingRight = !properties.facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
