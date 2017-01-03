using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//Camera control variables.
	GameObject player;
	public float sensitivity = 2.0f;

	// Use this for initialization
	void Start()
	{
		player = this.transform.parent.gameObject;

		//Locks the cursor in the editor.
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		//Mouse input.
		float horizontalInput = sensitivity * Input.GetAxis("Mouse X");
		float verticalInput = -1 * sensitivity * Input.GetAxis("Mouse Y");

		//Horizontal mouse movement.
		player.transform.Rotate(0, horizontalInput, 0);

		//Vertical mouse movement.
		/*
		Massive pain figuring this out. Due to the way Unity handles object rotation,
		it is not possible to simply clamp the vertical angle to -85, 85. Instead of going from 0 to -1,
		the engine decides to rotate from 0 to 359, treating 0 as 360. The solution to this is to add 
		360 to all x rotation values between 0 and a number larger than the minimum vertical view angle.
		I've hardcoded the viewing angle to be between -85 and positive 85. I'll come back eventually
		and insert a variable to allow for custom viewing angle restrictions.
		*/

		Vector3 rotation = transform.eulerAngles;

		if(rotation.x > 0 && rotation.x < 90)
		{
			//Setting an intial rotation between 0 and 90 causes the camera to jump to 275 degrees.
			//A starting angle around 350-360 avoids this issue. 
			rotation.x += 360;
		}

		rotation.x += verticalInput;
		rotation.x = Mathf.Clamp(rotation.x, 275, 445);
		transform.eulerAngles = rotation;
	}
}
