﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraEffects : MonoBehaviour {
	public static CameraEffects _instance;
	Transform target = null;
	public float yOffset = -5f,zOffset = 1f;
	public float speed = 0.03f;
	public GameObject winnerText;
	void Awake(){
		_instance = this;
	}
	void Start(){
		winnerText = GameObject.FindGameObjectWithTag ("WinnerText");
		winnerText.gameObject.SetActive (false);
	}
	void Update(){
		if (target != null) {
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0.0f,yOffset,zOffset), speed);
			winnerText.GetComponent<Text>().text = target.GetComponent<BallController> ().prefixInput + " wins";
			winnerText.gameObject.SetActive (true);
		}
	}
	public void FocusOnWinner(Transform player){
		target = player;
		winnerText.GetComponent<Text>().text = player.GetComponent<Player> ().prefixInput + " wins";
		winnerText.gameObject.SetActive (true);
	}
}
