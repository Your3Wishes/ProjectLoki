using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadBehaviour : MonoBehaviour
{
	//Launchpad variables.
	public float launchpadStrength;
	public Vector3 launchpadDirection;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Player")
		{
			Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
			playerRigidbody.AddForce(launchpadDirection * launchpadStrength, ForceMode.Impulse);
		}
	}
}
