using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public float spawnRate;
    public float timer;
    public float leftSpawnLimit;
    public float rightSpawnLimit;
    public float minSpawnRate;
    public float maxSpawnRate;
    public int spawnRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0f;
        minSpawnRate = 2f;
        maxSpawnRate = 5f;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        SpawnCar();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnCar();
            spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            timer = 0f;
        }
    }

    void SpawnCar()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(leftSpawnLimit, rightSpawnLimit),
            transform.position.y,
            transform.position.z
        );

        Quaternion spawnRot = Quaternion.Euler(0, 0, this.spawnRot); 

        Instantiate(car, spawnPos, spawnRot);
    }
    
}
