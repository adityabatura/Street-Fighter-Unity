using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;

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

		if (!grounded){
			//transform.position.y += 5 * Time.deltaTime;
			//transform.position = new  Vector2 (transform.position.x, transform.position.y +=5 * Time.deltaTime);
			transform.position = new  Vector2 (transform.position.x,transform.position.y - 15* Time.deltaTime);
		}
	
	}
}
