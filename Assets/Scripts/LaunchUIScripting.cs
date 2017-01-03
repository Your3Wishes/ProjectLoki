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

		//Hide the launch UI once the player has been launched.
		if(player.GetComponent<PlayerController>().hasPlayerBeenLaunched())
		{
			StartCoroutine(hideLaunchUI());
		}
		else
		{
			showLaunchUI();
		}
	}

	//Using a coroutine to hide the UI allows you to specify a wait time before it dissapears.
	IEnumerator hideLaunchUI()
	{
		yield return new WaitForSeconds(1);
		launchUICanvas.GetComponent<CanvasGroup>().alpha = 0;
	}

	public void showLaunchUI()
	{
		launchUICanvas.GetComponent<CanvasGroup>().alpha = 1;
	}
}
