using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadBehaviour : MonoBehaviour
{
	//Launchpad variables.
	public float launchpadStrength;
	public Vector3 launchpadDirection;

	private void OnCollisionEnter(Collision collision)
	{
		//Launches the player should they collide with the launchpad's collision box.
		if(collision.gameObject.name == "Player")
		{
			Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
			playerRigidbody.AddForce(launchpadDirection * launchpadStrength, ForceMode.Impulse);
		}
	}
}
