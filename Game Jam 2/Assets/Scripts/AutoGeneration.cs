using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoGeneration : MonoBehaviour
{
    [SerializeField] Transform parent;

    [SerializeField] List<GameObject> prefabs;

    [SerializeField] char nextPlatformType = 'a';

    [SerializeField] GameObject player;

    [SerializeField] float distanceInFrontToSpawn = 30;
    [SerializeField] float distanceBehindToDestroy = 30;

    List<GameObject> platformA = new List<GameObject>();
    List<GameObject> platformB = new List<GameObject>();
    List<GameObject> platformC = new List<GameObject>();

    Vector3 currentPos;

    void Awake()
    {
        // Set the initial position
        currentPos = parent.position;

        // Put the prefabs in the correct list
        foreach (var prefab in prefabs)
        {
            string name = prefab.name;

            switch (name[0])
            {
                case 'a':
                    platformA.Add(prefab);
                    break;
                case 'b':
                    platformB.Add(prefab);
                    break;
                case 'c':
                    platformC.Add(prefab);
                    break;
                default:
                    break;
            }
        }
    }

    void Update()
    {
        // Check if we should spawn a new platform
        if (player.transform.position.z - distanceInFrontToSpawn < currentPos.z)
            Spawn();

        // Check if we should destroy a platform
        Transform platform = parent.GetChild(0);
        if (player.transform.position.z + distanceBehindToDestroy < platform.position.z)
            Destroy(platform.gameObject);
    }

    void Spawn()
    {
        List<GameObject> platformList;
        switch (nextPlatformType)
        {
            case 'a':
                platformList = platformA;
                break;
            case 'b':
                platformList = platformB;
                break;
            case 'c':
                platformList = platformC;
                break;
            default:
                Debug.Assert(false, "Next Platform Type is incorrect");
                platformList = platformA;
                break;
        }

        GameObject randomPlatformPrefab = platformList[Random.Range(0, platformList.Count)];

        nextPlatformType = randomPlatformPrefab.name[randomPlatformPrefab.name.Length - 1];

        // Spawn the platform
        GameObject newPlatform = Instantiate(randomPlatformPrefab, currentPos, randomPlatformPrefab.transform.rotation);

        // Set the parent
        newPlatform.transform.parent = parent;

        // Set the next position
        currentPos = newPlatform.transform.GetChild(0).transform.position;
    }
}
