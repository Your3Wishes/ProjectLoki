using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//Player movement variables.
	public float movementMultiplier = 0.15f;
	public float strafeMultiplier = 0.15f;

	//Variables used to calculate current speed.
	private float playerSpeed = 0;
	Vector3 currentWorldPosition;
	Vector3 previousWorldPosition;

	//Variables used to calculate distance traveled.
	private float distanceTraveled = 0;
	Vector3 playerOriginPoint;

	//Player launch variables.
	public Vector3 launchVector;

	//Game area boundaries.
	public float minXBound, maxXBound, minYBound, maxYBound, minZBound, maxZBound;

	//Use this for initialization.
	void Start()
	{
		//Sets the player's origin point at game start.
		playerOriginPoint = transform.position;
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
	}

	//Update that is called every fixed timestamp duration.
	void FixedUpdate()
	{
		//Player movement.
		float movementSpeed = Input.GetAxis("Vertical") * movementMultiplier;
		float strafeSpeed = Input.GetAxis("Horizontal") * strafeMultiplier;
		transform.Translate(strafeSpeed, 0, movementSpeed);

		//Calculates the speed of the player.
		if(currentWorldPosition != previousWorldPosition)
		{
			previousWorldPosition = currentWorldPosition;
		}
		currentWorldPosition = this.transform.position;
		playerSpeed = Vector3.Distance(previousWorldPosition, currentWorldPosition) / Time.deltaTime;

		//Calculates the distance the player has traveled from the player's origin.
		distanceTraveled = Vector3.Distance(transform.position, playerOriginPoint);
	}

	public float getSpeed()
	{
		return playerSpeed;
	}

	public float getDistanceTraveled()
	{
		return distanceTraveled;
	}

	//Used to launch the player from the initial starting position.
	public void launchPlayer(Vector3 launchVector)
	{
		this.GetComponent<Rigidbody>().AddForce(launchVector, ForceMode.Impulse);
	}
}
