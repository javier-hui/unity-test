using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabRock;

    // saved for efficiency
    [SerializeField]
    Sprite rockWhite;
    [SerializeField]
    Sprite rockMagenta;
    [SerializeField]
    Sprite rockGreen;

    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    // spawn location support
    const int SpawnBorderSize = 100;
    int minSpawnX, maxSpawnX, minSpawnY, maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        // save spawn boundaries for efficiency
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // check for time to spawn a rock
        if (spawnTimer.Finished) {
            SpawnRock();

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnRock() {
        // generate random location and create new rock
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = worldLocation;

        SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        switch (spriteNumber) {
            case 0: spriteRenderer.sprite = rockWhite; break;
            case 1: spriteRenderer.sprite = rockMagenta; break;
            case 2: spriteRenderer.sprite = rockGreen; break;
        }
    }
}
