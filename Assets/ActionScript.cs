using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour {

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public bool grounded = false;

	public bool facingRight = true;
	public float jumpForce = 400f;
	public float moveForce = 20f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 2f;	

	private bool jump = false;
	private bool crouch = false;

	private bool lp = false;
	private bool mp = false;
	private bool hp = false;
	private bool lk = false;
	private bool mk = false;
	private bool hk = false;

	private bool right = false;
	private bool left = false;

	//Timers
	private float jumpTimer = 0.0f;
	public float lpTimer = 0.0f;


	private PlayerControlScript controller;

	public AnimationScript anim;
	// Use this for initialization
	void Start () {

		controller = GetComponent <PlayerControlScript> ();
		anim = GetComponentInChildren<AnimationScript>();


	}

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {
	
		/*jump = controller.jump;
		crouch = controller.crouch;
		lp = controller.lp;
		mp = controller.mp;
		hp = controller.hp;
		lk = controller.lk;
		mk = controller.mk;
		hk = controller.hk;
		left = controller.left;
		right = controller.right;*/

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); 

	}
	void FixedUpdate () {

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
	}

	public void Jump(){
		if(grounded && !crouch){
			if(jumpTimer==0){
				if (rigidbody2D.velocity.x==0){
					rigidbody2D.AddForce(new Vector2(0.0f, jumpForce));
				}else{
					if(rigidbody2D.velocity.x>0.1){
						rigidbody2D.AddForce(new Vector2(100f, jumpForce));
					}else if(rigidbody2D.velocity.x<-0.1){
						rigidbody2D.AddForce(new Vector2(-100f, jumpForce));
					}
				}
				anim.Jump();
				Debug.Log ("Jump");
				jumpTimer = Time.time+1.5f;
			}else if(Time.time < jumpTimer){
				Debug.Log ("Too Soon");
			}else if(Time.time > jumpTimer){
				jumpTimer = 0;	
			}
		}
	}

	/*public void JumpDiag(){
		if(grounded){
			if(jumpTimer==0){
				if(rigidbody2D.velocity.x>0.1){
					rigidbody2D.AddForce(new Vector2(100f, jumpForce));
				}else if(rigidbody2D.velocity.x<-0.1){
					rigidbody2D.AddForce(new Vector2(-100f, jumpForce));
				}else{
					return;
				}
				anim.Jump();
				Debug.Log ("Jump");
				jumpTimer = Time.time+1.5f;
			}else if(Time.time < jumpTimer){
				Debug.Log ("Too Soon");
			}else if(Time.time > jumpTimer){
				jumpTimer = 0;	
			}
		}


	}*/

	public void Crouch(){
		if(grounded){
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
		if(lpTimer==0){
			Debug.Log ("Low Punch");
			lpTimer = Time.time+3.7f;
		}else if(Time.time < lpTimer){
			Debug.Log ("Too Soon");
		}else if(Time.time > lpTimer){

			lpTimer = 0;

		}
	}
	public void MP(){
		Debug.Log ("Mid Punch");
	}
	public void HP(){
		Debug.Log ("High Punch");
	}
	public void LK(){
		Debug.Log ("Low Kick");
	}
	public void MK(){
		Debug.Log ("Mid Kick");
	}
	public void HK(){
		Debug.Log ("High Kick");
	}
	public void Right(){
		if(!crouch && !jump && grounded){
			rigidbody2D.AddForce(Vector2.right * 1 * moveForce);
			Debug.Log ("Right");
		}
	}
	public void Left(){
		if(!crouch && !jump && grounded){
			rigidbody2D.AddForce(Vector2.right * -1 * moveForce);
			Debug.Log ("Left");
		}
	}

	public void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
