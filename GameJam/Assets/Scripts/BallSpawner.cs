using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay=1f;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private Vector3 direction;
    [SerializeField] GameObject prefab;
    [SerializeField] private float speed;
    [SerializeField] private float delay;
    [SerializeField] Transform respawnPoint;
    
    float currentTime;

    void Awake()
    {
        currentTime = spawnDelay-0.1f;
    }
    
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnDelay)
        {
            GameObject newBall = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            newBall.GetComponent<BallBehaviour>().SetParams(direction, speed, delay);
            newBall.GetComponent<Traps>().SetRespawn(respawnPoint);
            currentTime = 0;
        }
    }
}
