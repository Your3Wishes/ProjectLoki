using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	GameObject player;
	GameObject ground;
	int groundIndex;

	void Start()
	{
		player = GameObject.Find("Player");
		ground = Resources.Load("Prefabs/Ground", typeof(GameObject)) as GameObject;
	}

	void Update()
	{
		if(player.transform.position.z >= (groundIndex * 500) - 2000)
		{
			generateGround();
		}
	}

	//Advances the ground index and instantiates the next section of ground.
	private void generateGround()
	{
		Instantiate(ground, new Vector3(0, 0, (groundIndex * 500) + 250), new Quaternion(0, 0, 0, 0), this.transform);
		groundIndex++;
	}
}
