using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchUIScripting : MonoBehaviour
{
	GameObject magnitudeSliderGameObject;
	GameObject launchUICanvas;
	GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
		magnitudeSliderGameObject = GameObject.Find("Magnitude");
		launchUICanvas = GameObject.Find("LaunchUI");
	}

	void Update()
	{
		//Oscillate the magnitude slider.
		magnitudeSliderGameObject.GetComponent<Slider>().value = player.GetComponent<PlayerController>().getLaunchMagnitude();

		//Hide the 
		if(player.GetComponent<PlayerController>().hasPlayerBeenLaunched())
		{
			launchUICanvas.GetComponent<CanvasGroup>().alpha = 0;
		}
	}
}
