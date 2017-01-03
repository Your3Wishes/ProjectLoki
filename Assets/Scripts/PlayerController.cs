using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	#region Variables
	Transform playerCamera;

	//Rocket pack variables.
	public float jetpackStrength = 1;

	//Variables used to calculate current speed.
	private float playerSpeed = 0;
	Vector3 currentWorldPosition;
	Vector3 previousWorldPosition;

	//Variables used to calculate distance traveled.
	private float distanceTraveled = 0;
	Vector3 playerOriginPoint;

	//Player launch variables.
	private bool playerLaunched;
	private float launchMagnitude;
	public float launchMultiplier = 1f;

	//Game area boundaries.
	public float minXBound, maxXBound, minYBound, maxYBound, minZBound, maxZBound;
	#endregion

	//Called upon object initialization.
	void Start()
	{
		//Finds the player's camera.
		playerCamera = transform.Find("PlayerCamera");

		//Sets the player's origin point at game start.
		playerOriginPoint = transform.position;

		//Indicates the player has not been launched yet.
		playerLaunched = false;
		launchMagnitude = 0f;
	}

	//Update that is called once per frame.
	void Update()
	{
		//Game area boundary clamping.
		#region Game Area Boundary Logic
		/*
		Game area boundary clamping logic prevents the player from surpassing certain values
		specified in the player controller inspector in Unity. I decided to institute programmed
		boundaries instead of creating invisible walls in the map because it should be less resource
		intensive than creating physical objects in the world to block player movement.
		
		I don't forsee a need to limit the upper z and y axis boundaries, however the logic exists here
		should a need arise in the future.
		*/
		if(transform.position.x < minXBound)
			transform.position = new Vector3(minXBound, transform.position.y, transform.position.z);
		if(transform.position.x > maxXBound)
			transform.position = new Vector3(maxXBound, transform.position.y, transform.position.z);
		if(transform.position.y < minYBound)
			transform.position = new Vector3(transform.position.x, minYBound, transform.position.z);
		if(transform.position.y > maxYBound)
			transform.position = new Vector3(transform.position.x, maxYBound, transform.position.z);
		if(transform.position.z < minZBound)
			transform.position = new Vector3(transform.position.x, transform.position.y, minZBound);
		if(transform.position.z > maxZBound)
			transform.position = new Vector3(transform.position.x, transform.position.y, maxZBound);
		#endregion

		//If the player has not been launched.
		if(!playerLaunched)
		{
			//Lock the player to it's starting point.
			transform.position = playerOriginPoint;

			//Oscilate the launch magnitude between two values.
			launchMagnitude = ((Mathf.Sin(Time.time * 3) * 25) + 25);

			//Launch the player.
			if(Input.GetKeyDown(KeyCode.Space))
			{
				launchPlayer(launchMagnitude);
			}
		}

		//Reset the player.
		if(Input.GetKeyDown(KeyCode.Return))
		{
			resetPlayer();
		}

		//Rockets the player in the direction their facing.
		if(Input.GetKey(KeyCode.Space))
		{
			useJetPack();
		}
	}

	//Update that is called every fixed timestamp duration.
	void FixedUpdate()
	{
		#region Variable Calculation
		//Calculates the speed of the player.
		if(currentWorldPosition != previousWorldPosition)
		{
			previousWorldPosition = currentWorldPosition;
		}
		currentWorldPosition = this.transform.position;
		playerSpeed = Vector3.Distance(previousWorldPosition, currentWorldPosition) / Time.deltaTime;

		//Calculates the distance the player has traveled from the player's origin.
		distanceTraveled = Vector3.Distance(transform.position, playerOriginPoint);
		#endregion
	}

	public float getSpeed()
	{
		return playerSpeed;
	}

	public float getDistanceTraveled()
	{
		return distanceTraveled;
	}

	public bool hasPlayerBeenLaunched()
	{
		return playerLaunched;
	}

	public float getLaunchMagnitude()
	{
		return launchMagnitude;
	}

	//Used to launch the player from the initial starting position.
	private void launchPlayer(float launchMagnitude)
	{
		//The player is launched in the direction the camera is facing.
		playerLaunched = true;
		GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * launchMagnitude * launchMultiplier, ForceMode.Impulse);
	}

	//Used to reset the player.
	private void resetPlayer()
	{
		//Player has not been launched.
		playerLaunched = false;

		//Resets the ground index to 0.
		GameObject.Find("GroundGenerator").GetComponent<GroundGenerator>().groundIndex = 0;

		//Deletes all ground objects that have been made.
		foreach(Transform child in GameObject.Find("GroundGenerator").transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		//Resets the player position.
		transform.position = playerOriginPoint;

		//Resets the rigidbody velocity.
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	//Allows the player to travel in the direction their facing.
	private void useJetPack()
	{
		GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * jetpackStrength, ForceMode.VelocityChange);
	}
}
