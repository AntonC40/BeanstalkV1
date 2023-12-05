using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class PlayerSprites
{
	public Sprite playerState { get { return _playerState; } }

	//serialize private variables
	private Sprite _playerState;

	public PlayerSprites(Sprite playerState)
	{
		this._playerState = playerState;
	}
}


public class PlayerController : MonoBehaviour {
	
	public float jumpHeight = 5;
	public float horizantalSpeed = 5;
	public Text healthText;
	public Text scoreText;
	public Sprite playerSprite;

	public static int finalScore;
   
	private float canJump;
	private int playerHealth = 10;
	private int score = 0;
	private bool alreadyTouched;
    Animator m_Animator;

	//array from the PlayerSprites class
	[Header("Sprites")]
	public PlayerSprites[] PlayerSprite = new PlayerSprites[7];
	public static Sprite state1;
	public static Sprite state2;
	public static Sprite state3;
	public static Sprite state4;
	public static Sprite state5;
	public static Sprite state6;
	public static Sprite state7;
	public static Sprite state8;


	public Sprite[] PlayerSprites = new Sprite[6] {state1, state2, state3, state4, state5, state6};

	private int spriteNum = 1;
	private float timeFalling;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
		score = 0;
		this.GetComponent<SpriteRenderer>().sprite = playerSprite;
		DisplayStats ();
    }

	void Update () 
	{
		LaunchOnMouseClick();
		Translation();
		playerSprite = PlayerSprites [spriteNum];
		finalScore = score;
		timeFalling = Time.time + 5.0f;
		if (playerHealth <= 0) {
			Death ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
			Debug.Log ("Colided with a platform.");
			timeFalling = 0;
			//rhis was supposed to trigger the jump animation
		    //m_Animator.SetBool ("platform", true); //I used this for reference on how to change animation https://docs.unity3d.com/ScriptReference/Animator.SetBool
			

		//This portion of the method should prevent the player from scoring by jumping on the same platform mjultiple times. 
		if (collision.gameObject.tag == "Platform"){
			collision.gameObject.tag = ("AlreadyTouched");
			score += 1;
			DisplayStats ();
		}
	}

	private void LaunchOnMouseClick()
	{
		if(Input.GetMouseButtonDown(0) && Time.time > canJump){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpHeight);
			canJump = Time.time + 2.0f; 
			// Reference for how to keep player from spamming a button from Mmmpies & Derek-Wong: 
			//https://answers.unity.com/questions/890258/have-a-delay-after-each-jump-so-user-cant-spam-jum.html
		}
	}

	//This function controls movement from left to right.
	private void Translation()
	{
		var movement = Input.GetAxis("Horizontal")* Time.deltaTime * horizantalSpeed;
		transform.Translate(movement,0, 0);
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}

    //This is a coroutine that responds to collisions based on the prefab.
	//I used a coroutine to wait for a few seconds before changing the bool "cloud" back to false
	//which returns the player sprite back to the idle animation
	//I used these links for reference: https://answers.unity.com/questions/297087/yieldontriggerenter-help-c.html
	//https://docs.unity3d.com/Manual/Coroutines.html

	IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.gameObject.tag == "Cloud") {
			Debug.Log ("Colided with a cloud.");
			m_Animator.SetBool ("cloud", true);
			playerHealth -= 1;
			spriteNum += 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();

			yield return new WaitForSeconds (2);
			m_Animator.SetBool ("cloud", false);

		} else if (collider.gameObject.tag == "Axe") {
			Debug.Log ("Colided with an axe");
			playerHealth -= 1;
			spriteNum += 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();
		} else if (collider.gameObject.tag == "Anvil") {
			Debug.Log ("Colided with an anvil");
			playerHealth -= 3;
			spriteNum += 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();
		} else if (collider.gameObject.tag == "Bird") {
			Debug.Log ("Colided with a bird");
			playerHealth -= 1;
			spriteNum += 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();
		} else if (collider.gameObject.tag == "Golden Egg") {
			Debug.Log ("Colided with an axe");
			score += 1;
			spriteNum -= 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();
		} else if (collider.gameObject.tag == "Green Bean") {
		Debug.Log ("Colided with a green seed");
			playerHealth += 1;
			spriteNum -= 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();
		} else if (collider.gameObject.tag == "Red Bean") {
		Debug.Log ("Colided with an axe");
			playerHealth += 2;
			spriteNum -= 1;
			GetComponent<SpriteRenderer>().sprite = playerSprite;
			DisplayStats ();
		}
    }

	// A method to update the player's health and score
	void DisplayStats(){
		healthText.text = "Health: " + playerHealth.ToString ();
		scoreText.text = "Score: " + score.ToString();
	}

	void Death(){
		finalScore = score;
		SceneManager.LoadScene (1);
	}
		
}
