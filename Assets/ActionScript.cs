using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour {

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


	private PlayerControlScript controller;
	// Use this for initialization
	void Start () {

		controller = GetComponent <PlayerControlScript> ();


	}
	
	// Update is called once per frame
	void Update () {
	
		jump = controller.jump;
		crouch = controller.crouch;
		lp = controller.lp;
		mp = controller.mp;
		hp = controller.hp;
		lk = controller.lk;
		mk = controller.mk;
		hk = controller.hk;
		left = controller.left;
		right = controller.right;

	}
	void FixedUpdate () {
		if(jump)
		{
			Jump();
		}
		if(crouch)
		{
			Crouch();
		}

		float h = Input.GetAxis("Horizontal");

		if(right){
			Right (h);
		}
		if(left){
			Left (h);
		}
		/*if(h * rigidbody2D.velocity.x < maxSpeed && !crouch && grounded)
		{

		}*/

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
	}

	void Jump(){
		rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		Debug.Log ("Jump");
	}

	void Crouch(){
		Debug.Log ("Crouch");
	}

	void LP(){
		Debug.Log ("Low Punch");
	}
	void MP(){
		Debug.Log ("Mid Punch");
	}
	void HP(){
		Debug.Log ("High Punch");
	}
	void LK(){
		Debug.Log ("Low Kick");
	}
	void MK(){
		Debug.Log ("Mid Kick");
	}
	void HK(){
		Debug.Log ("High Kick");
	}
	void Right(float h){
		rigidbody2D.AddForce(Vector2.right * h * moveForce);
		Debug.Log ("Right");
	}
	void Left(float h){
		rigidbody2D.AddForce(Vector2.right * h * moveForce);
		Debug.Log ("Left");
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
