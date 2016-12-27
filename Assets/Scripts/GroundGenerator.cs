using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	private GameObject player;
	private Transform ground;
	private int groundIndex;

	void Start()
	{
		player = GameObject.Find("Player");
		ground = this.transform.GetChild(0);
	}

	void Update()
	{
		if(player.transform.position.z >= (groundIndex * 1000) - 750)
		{
			generateGround();
		}
		print(groundIndex);
	}

	private void generateGround()
	{
		groundIndex++;
		Instantiate(ground, new Vector3(0, 0, groundIndex * 1000), new Quaternion(0, 0, 0, 0), this.transform);
	}
}
