using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGeneration : MonoBehaviour
{
    [SerializeField] Transform parent;

    [SerializeField] GameObject slopePrefab;

    [SerializeField] GameObject player;

    Vector3 currentPos;

    [SerializeField] float distanceInFrontToSpawn = 30;
    [SerializeField] float distanceBehindToDestroy = 30;

    void Start() 
	{
        currentPos = parent.position;

    }

    void Update()
    {
        // Check if we should spawn a new platform
        if (player.transform.position.z - distanceInFrontToSpawn < currentPos.z)
        {
            Spawn();
        }

        // Check if we should destroy a platform
        Transform platform = parent.GetChild(0);
        if (player.transform.position.z + distanceBehindToDestroy < platform.position.z)
        {
            Destroy(platform.gameObject);
        }
    }

    void Spawn() 
	{

        // Spawn the platform
        GameObject newPlatform = Instantiate(slopePrefab, currentPos, slopePrefab.transform.rotation);

        // Set the parent
        newPlatform.transform.parent = parent;

        // Set the next position
        currentPos = newPlatform.transform.GetChild(0).transform.position;

	}
}
