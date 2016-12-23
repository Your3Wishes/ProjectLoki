using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUIScripting : MonoBehaviour
{
	GameObject SpeedometerGameObject;
	GameObject OdometerGameObject;
	GameObject player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		SpeedometerGameObject = GameObject.Find("Speedometer");
		OdometerGameObject = GameObject.Find("Odometer");
	}

	private void Update()
	{
		SpeedometerGameObject.GetComponent<Text>().text = "SPEED: " + Mathf.Round(player.GetComponent<PlayerController>().getSpeed()) + " m/s";
		OdometerGameObject.GetComponent<Text>().text = "DISTANCE: " + Mathf.Round(player.GetComponent<PlayerController>().getDistanceTraveled()) + " meters";
	}
}
