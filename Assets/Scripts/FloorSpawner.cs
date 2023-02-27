using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;

    private float timer = 0;

    [SerializeField] float spawnRate;
    [SerializeField] float heighOffset;

    void FixedUpdate() {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn() {
        float highestPoint = transform.position.y - heighOffset;
        float lowestPoint = transform.position.y + heighOffset;

        Instantiate(floor, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), gameObject.transform.rotation);
    }

    public void DecreaseSpawnRate(float rate) {
        spawnRate -= rate;
    }
}
