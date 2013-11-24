using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {
	
	


	/*public bool left = false;
	public bool right = false;
	public bool jump = false;
	public bool crouch = false;
	
	
	public bool lp = false;
	public bool mp = false;
	public bool hp = false;
	public bool lk = false;
	public bool mk = false;
	public bool hk = false;*/
	
	public ActionScript actionController;
	
	// Use this for initialization
	void Start () {
		
		actionController = GetComponent <ActionScript>();
	}
	

	
	
	// Update is called once per frame
	void Update () {
		
		 
		
		//Movement
		if(Input.GetKey(KeyCode.A))
			actionController.Left();
		if(Input.GetKey(KeyCode.D))
			actionController.Right();

		if(Input.GetKey(KeyCode.S))
			actionController.Crouch();
		if(Input.GetKeyUp(KeyCode.S))
			actionController.CrouchOff();
		if(Input.GetKey(KeyCode.W))
			actionController.Jump();
		/*if(Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))){
			actionController.JumpDiag();
			Debug.Log("Diag");
		}*/
		//Punches
		if(Input.GetKeyDown(KeyCode.Y))
			actionController.LP ();
		if(Input.GetKeyDown(KeyCode.U))
			actionController.MP ();
		if(Input.GetKeyDown(KeyCode.I))
			actionController.HP ();
		//Kicks
		if(Input.GetKeyDown(KeyCode.H))	
			actionController.LK ();
		if(Input.GetKeyDown(KeyCode.J))
			actionController.MK ();		
		if(Input.GetKeyDown(KeyCode.K))
			actionController.HK ();

		
		//if(Input.GetKeyDown(KeyCode.T))
			//Debug.Log (Time.time);

	}
	
	void FixedUpdate(){
		
	}
	
	
	
}
