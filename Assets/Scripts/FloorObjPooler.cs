using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorObjPooler : MonoBehaviour {
    public static FloorObjPooler Instance;

    private void Awake() {
        Instance = this;
        Debug.Log(Instance);
    }

    [System.Serializable]
    public class FloorPool {
        public GameObject prefab;
        public int size;
    }

    [SerializeField] private List<FloorPool> floorObjPools;
    private Queue<GameObject> floorObjQueue;

    private void Start() {

        foreach (FloorPool floorPool in floorObjPools) {
            Queue<GameObject> objectPoolQueue = new Queue<GameObject>();
            
            for (int i = 0; i < floorPool.size; i++) {
                GameObject obj = Instantiate(floorPool.prefab);
                obj.SetActive(false);

                objectPoolQueue.Enqueue(obj);
            }
            floorObjQueue = objectPoolQueue;
        }
    }

    public GameObject SpawnFromPool(Vector3 position) {
        GameObject objectToSpawn = floorObjQueue.Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        floorObjQueue.Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
