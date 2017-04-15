using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private Player player;

	public Text hpText;
	public Text ammoText;
	public Text scoreText;

    //public Text scoreText; 

	void Start () {
        player = FindObjectOfType<Player>();
	}

	void Update () {
        hpText.text = player.playerHp + "%";
		ammoText.text = player.remainingMagazine + " / " + player.fullMagzine;

        scoreText.text = player.score + "점";
	}
}
