using UnityEngine;
using System.Collections;

public class ActionScriptOld : MonoBehaviour {
	
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
	
	
	private PlayerControlScript controller;
	// Use this for initialization
	void Start () {
		
		controller = GetComponent <PlayerControlScript> ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	/*	jump = controller.jump;
		crouch = controller.crouch;
		lp = controller.lp;
		mp = controller.mp;
		hp = controller.hp;
		lk = controller.lk;
		mk = controller.mk;
		hk = controller.hk;
		left = controller.left;
		right = controller.right;
		*/
		
	}
	void FixedUpdate () {
		/*if(jump)
		{
			Jump();
		}
		if(crouch)
		{
			Crouch();
		}*/
		
		float h = Input.GetAxis("Horizontal");
		
		/*if(right){
			Right (h);
		}
		if(left){
			Left (h);
		}
		if(lp){
			LP ();
		}
		if(mp){
			MP ();
		}
		if(hp){
			HP ();
		}
		if(lk){
			LK ();
		}
		if(mk){
			MK ();
		}
		if(hk){
			HK ();
		}*/
		
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
	}
	
	public void Jump(){
		
		/*if((jumpTimer+6)<Time.time){
			jumpTimer= Time.time;
			Debug.Log ("Not Greater");
		}else{}*/
		rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		Debug.Log ("Jump");
		
	}
	
	public void Crouch(){
		Debug.Log ("Crouch");
	}
	
	public void LP(){
		Debug.Log ("Low Punch");
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
	public void Right(float h){
		rigidbody2D.AddForce(Vector2.right * h * moveForce);
		Debug.Log ("Right");
	}
	public void Left(float h){
		rigidbody2D.AddForce(Vector2.right * h * moveForce);
		Debug.Log ("Left");
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
