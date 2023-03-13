using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour {
    private FloorObjPooler floorObjPooler;

    private void Start() {
        floorObjPooler = FloorObjPooler.Instance;
    }

    private float timer = 0;

    [SerializeField] float spawnRate;
    [SerializeField] float heighOffset;

    private void FixedUpdate() {
        if(timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            Spawn();
            timer = 0;
        }
    }

    void Spawn() {
        float highestPoint = transform.position.y - heighOffset;
        float lowestPoint = transform.position.y + heighOffset;

        floorObjPooler.SpawnFromPool(new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0));
    }

    public void DecreaseSpawnRate(float rate) {
        spawnRate -= rate;
    }
}
