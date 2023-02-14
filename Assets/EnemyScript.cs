using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{
    public void SpawnEnemy(bool flag) {
        if (flag == true) {
            gameObject.SetActive(flag);
        } else {
            gameObject.SetActive(flag);
        }
    }
}
