using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Player player;
	public Text scoreText;

	private int score;


	// Use this for initialization
	void Start () {
		player.onCollectCoin = OnCollectCoin;
	
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

	void OnCollectCoin () {
		score++;
		scoreText.text = "Score: " + score;
	
	}
}
