using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	GameObject player;
	Transform ground;
	int groundIndex;

	void Start()
	{
		player = GameObject.Find("Player");
		ground = this.transform.GetChild(0);
	}

	void Update()
	{
		//Generates the next section of ground when the player is 2000 meters away from the end of the ground objects.
		if(player.transform.position.z >= (groundIndex * 1000) - 2000)
		{
			generateGround();
		}
	}

	//Advances the ground index and instantiates the next section of ground.
	private void generateGround()
	{
		//Keeps track of how many ground objects have been created.
		groundIndex++;
		Instantiate(ground, new Vector3(0, 0, groundIndex * 1000), new Quaternion(0, 0, 0, 0), this.transform);
	}
}
