using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//Player variables.
	public float movementMultiplier = 0.15f;
	public float strafeMultiplier = 0.15f;

	//Speed calculation variables.
	private float playerSpeed = 0;
	Vector3 currentWorldPosition;
	Vector3 previousWorldPosition;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	//Update called every fixed timestamp duration.
	void FixedUpdate()
	{
		//Player movement.
		float movementSpeed = Input.GetAxis("Vertical") * movementMultiplier;
		float strafeSpeed = Input.GetAxis("Horizontal") * strafeMultiplier;
		transform.Translate(strafeSpeed, 0, movementSpeed);

		//Calculates the speed of the player.
		if (currentWorldPosition != previousWorldPosition)
		{
			previousWorldPosition = currentWorldPosition;
		}
		currentWorldPosition = this.transform.position;
		playerSpeed = Vector3.Distance(previousWorldPosition, currentWorldPosition) / Time.deltaTime;
	}

	public float getSpeed()
	{
		return playerSpeed;
	}
}
