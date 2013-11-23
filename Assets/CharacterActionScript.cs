using UnityEngine;
using System.Collections;

public class CharacterActionScript : MonoBehaviour {

	//public string[] buttons;
	private int currentIndex = 0; //moves along the array as buttons are pressed
	
	public float allowedTimeBetweenButtons = 0.3f; //tweak as needed
	private float timeLastButtonPressed;

	private string[] hadouken = new string[] {"down","right","y"};
	private string[] shoryuken = new string[] {"down","right","down","y"};

	private RyuAnimationScript anim;
	private PlayerProperties properties;


	// Use this for initialization
	void Start () {
	
		anim = GetComponentInChildren<RyuAnimationScript>();
		properties = GetComponent<PlayerProperties>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Check(hadouken)){
			Hadouken();

		}
		if(Check(shoryuken)){
			Shoryuken();
			
		}

		//if(hadouken[2] == Input.GetKeyDown(KeyCode.Y))Debug.Log("Hadouken"); 

	
	}

	public bool Check(string[] buttons){

		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
		{
			if (currentIndex < buttons.Length)
			{
				if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
				    (buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
				    (buttons[currentIndex] == "left" && Input.GetAxisRaw("Vertical") == -1) ||
				    (buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1) ||
				    (buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "left" && buttons[currentIndex] != "right" && Input.GetKey(buttons[currentIndex])))
				{
					timeLastButtonPressed = Time.time;
					currentIndex++;
				}
				
				if (currentIndex >= buttons.Length)
				{
					currentIndex = 0;
					return true;
				}
				else return false;
			}
		}
		
		return false;


	}

	public void Hadouken(){
		if(properties.moveTimer==0){
			anim.Hadouken();
			Debug.Log("Hadouken"); 
			properties.moveTimer = Time.time+1.0f;
			StartCoroutine(properties.Recover(1.5f));
		}else if(Time.time < properties.moveTimer){
			Debug.Log ("Too Soon");
		}else if(Time.time > properties.moveTimer){
			
			properties.moveTimer = 0;
			
		}
	}

	public void Shoryuken(){
		if(properties.moveTimer==0){
//			anim.Shoryuken();
			Debug.Log("Shoryuken"); 
			properties.moveTimer = Time.time+1.0f;
			StartCoroutine(properties.Recover(1.5f));
		}else if(Time.time < properties.moveTimer){
			Debug.Log ("Too Soon");
		}else if(Time.time > properties.moveTimer){
			
			properties.moveTimer = 0;
			
		}
	}
}
