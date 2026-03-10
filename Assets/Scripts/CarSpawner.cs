using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    private PlayerController player;
    
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Vector3 spawnDirection;

    public List<GameObject> vehiclePrefabs;
    public float minDelay = 1f;
    public float maxDelay = 3f;
    
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        PickDelay();
    }

    private void PickDelay()
    {
        timer = Random.Range(minDelay, maxDelay);
    }

    private void SpawnVehicle()
    {
        GameObject go = GameObject.Instantiate(vehiclePrefabs[Random.Range(0, vehiclePrefabs.Count)], spawnPosition.position,
            transform.rotation);

        Vehicle v = go.GetComponent<Vehicle>();
        v.direction = spawnDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hasDied) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            PickDelay();
            SpawnVehicle();
        }
    }
}
