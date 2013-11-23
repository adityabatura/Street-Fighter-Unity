using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	public int Health;
	public int Stun;
	
	public bool facingRight = true;
	public float jumpForce = 400f;
	public float moveForce = 20f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 2f;	

	public bool grounded;

	//Timers
	public float jumpTimer = 0.0f;
	public float moveTimer = 0.0f;
	public bool recovered = true;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		grounded = GetComponent<ActionScript>().grounded;
	}

	void FixedUpdate () {
		
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
	}

	public IEnumerator Recover(float waitTime) {
		recovered = false;
		yield return new WaitForSeconds(waitTime);
		//print("WaitAndPrint " + Time.time);
		recovered = true;
	}
}
