using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Player player;

	public Text hpText;
	public Text ammoText;
	public Text kmText;

	//public Text scoreText; 

	void Start () {
		
	}

	void Update () {
		//hpText.text = AllData.GetInstance().GetPlayerHp() + "%";
		ammoText.text = player.remainingMagazine + " / " + player.fullMagzine;

		//Debug.LogError (hpText.text);
	}
}
