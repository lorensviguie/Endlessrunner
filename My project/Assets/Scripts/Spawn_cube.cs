using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 2f;
    public float despawnAngle = 900f;
    public float cubeHeightOffset = 0.1f;

    private float nextSpawnTime;

    void Update()
    {
        // Rotate the cylinder
        float rotationAmount = Time.deltaTime * 20f; // You can adjust the rotation speed if needed
        transform.Rotate(Vector3.up * rotationAmount);

        // Check if it's time to spawn a cube
        if (Time.time >= nextSpawnTime)
        {
            SpawnCube();
            nextSpawnTime = Time.time + spawnInterval;
        }

        // Check if the cylinder has rotated enough to despawn cubes
        if (transform.rotation.eulerAngles.y >= despawnAngle)
        {
            DestroyCubes();
        }
    }

    void SpawnCube()
    {
        // Calculate a random position on the top of the cylinder
        float randomX = Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f);
        Vector3 spawnPosition = new Vector3(randomX, transform.localScale.y / 2f + cubeHeightOffset, 0f);

        // Apply the rotation of the cylinder to the spawn position
        spawnPosition = transform.rotation * spawnPosition;

        // Spawn the cube
        GameObject newCube = Instantiate(cubePrefab, transform.TransformPoint(spawnPosition), Quaternion.identity);

        // Make the spawned cube a child of the rotating cylinder
        newCube.transform.parent = transform;
    }

    void DestroyCubes()
    {
        // Destroy all cubes that are children of the rotating cylinder
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Cube"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
