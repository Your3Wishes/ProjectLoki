using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlankSpawnLaunchpads : MonoBehaviour {

    public GameObject redLaunchPadPrefab;
    public GameObject goldLaunchPadPrefab;
    float spawnLaunchPadPercentage = 80.0f;
    float goldLaunchPadPercentage = 5.0f;

    // Use this for initialization
    void Start ()
    {
        generateLaunchpads();
	}

    // Spawn Launchpads for this chunk of ground. 
    private void generateLaunchpads()
    {
        for (int i = 0; i < 20; i++)
        {
            float randomChance = Random.Range(0, 100);

            // Only spawn a launch pad via spawnLaunchPadPercentage chance.
            if (randomChance < spawnLaunchPadPercentage)
            {
                float xLocation = Random.Range(-50.0f, 50.0f);
                float zLocation = this.transform.position.z - 250 + (i * 25);

                // Spawn gold launchpad if lucky, else spawn a red launchpad
                if (randomChance < goldLaunchPadPercentage)
                    Instantiate(goldLaunchPadPrefab, new Vector3(xLocation, 0, zLocation), new Quaternion(0, 0, 0, 0), this.transform);
                else
                    Instantiate(redLaunchPadPrefab, new Vector3(xLocation, 0, zLocation), new Quaternion(0, 0, 0, 0), this.transform);
            }
        }
    }
}
