using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUIScripting : MonoBehaviour
{
	GameObject speedometerGameObject;
	GameObject odometerGameObject;
	GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
		speedometerGameObject = GameObject.Find("Speedometer");
		odometerGameObject = GameObject.Find("Odometer");
	}

	private void Update()
	{
		//Sets the speedometer.
		speedometerGameObject.GetComponent<Text>().text = "SPEED: " + Mathf.Round(player.GetComponent<PlayerController>().getSpeed()) + " m/s";

		//Sets the odometer.
		odometerGameObject.GetComponent<Text>().text = "DISTANCE: " + Mathf.Round(player.GetComponent<PlayerController>().getDistanceTraveled()) + " meters";
	}
}
