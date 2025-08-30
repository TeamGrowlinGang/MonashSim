using UnityEngine;

public class RoadMarkSpawner : MonoBehaviour
{
    public GameObject roadMark;
    public float spawnRate;
    private float timer;

    void Start()
    {
        timer = 0f;
        spawnRate = .5f;
        SpawnRoadMark();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnRoadMark();
            timer = 0f;
        }
    }

    void SpawnRoadMark()
    {
        Instantiate(roadMark, transform.position, transform.rotation);
    }
}