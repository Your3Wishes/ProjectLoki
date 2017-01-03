using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPrefabBehaviour : MonoBehaviour
{
	GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
	}

	void Update()
	{
		if(player.transform.position.z >= this.transform.position.z + 500)
		{
			DestroyImmediate(this.gameObject);
		}
	}
}
