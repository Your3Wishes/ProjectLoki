using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSignBehaviour : MonoBehaviour
{
	public float scrollSpeed = 0.1f;
	public float colorChangeSpeed = 2f;
	Material warningSignMaterial;
	private float xOffset;
	private Color transitionColor;
	private float transitionPercentage;

	void Start()
	{
		warningSignMaterial = GetComponent<Renderer>().material;
		warningSignMaterial.EnableKeyword("_EMISSION");
	}

	void Update()
	{
		//Scrolls the x offset of the texture along the plane.
		xOffset += scrollSpeed * Time.deltaTime;
		if(xOffset >= 1)
		{
			xOffset = 0;
		}

		warningSignMaterial.mainTextureOffset = new Vector2(xOffset, 0);

		//Changes the color of the emission.
		transitionPercentage = (Mathf.Tan(Time.time * colorChangeSpeed) * .5f) + .5f;
		transitionColor = Color.Lerp(Color.red, Color.black, transitionPercentage);
		print(transitionPercentage);
		warningSignMaterial.SetColor("_EmissionColor", transitionColor);
	}
}
