using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUIScripting : MonoBehaviour
{
	GameObject SpeedometerGameObject;
	GameObject player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		SpeedometerGameObject = GameObject.Find("Speedometer");
	}

	private void Update()
	{
		SpeedometerGameObject.GetComponent<Text>().text = "" + Mathf.Round(player.GetComponent<PlayerController>().getSpeed());
	}
}
