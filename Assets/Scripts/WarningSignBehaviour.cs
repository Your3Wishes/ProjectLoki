using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSignBehaviour : MonoBehaviour
{
	public float scrollSpeed = 0.1f;
	public float colorChangeSpeed = 2f;

	Material warningSignMaterial;
	Transform warningSignLight;

	float xAxisOffset;
	Color transitionColor;
	float transitionPercentage;

	void Start()
	{
		warningSignMaterial = GetComponent<Renderer>().material;
		warningSignMaterial.EnableKeyword("_EMISSION");
		warningSignLight = this.transform.GetChild(0);
	}

	void Update()
	{
		//Scrolls the x axis offset of the texture along the plane.
		xAxisOffset += scrollSpeed * Time.deltaTime;
		if(xAxisOffset >= 1)
		{
			xAxisOffset = 0;
		}

		warningSignMaterial.mainTextureOffset = new Vector2(xAxisOffset, 0);

		//Changes the color of the emission and the light since emissions don't work properly.
		transitionPercentage = (Mathf.Tan(Time.time * colorChangeSpeed) * .5f) + .5f;
		transitionColor = Color.Lerp(Color.red, Color.black, transitionPercentage);
		warningSignMaterial.SetColor("_EmissionColor", transitionColor);
		warningSignLight.GetComponent<Light>().color = transitionColor;
	}
}
