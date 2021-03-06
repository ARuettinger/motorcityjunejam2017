﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject spawnableObject;
    [SerializeField] private float spawnFrequency = 1f;
    [SerializeField] private int spawnCount = 3;

    private bool isActivated = false;
    private int spawnedCount;

    void Start() {

    }

    void Update() {

    }

    public void Activate() {
        if (isActivated) return;

        isActivated = true;

        StartCoroutine(Spawn());
    }

    public bool IsActivated() {
        return isActivated;
    }

    private IEnumerator Spawn() {
        GameObject enemy = Instantiate(spawnableObject, transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().targetPosition = GameManager.Instance.Player.transform;
        spawnedCount++;

        if (spawnedCount < spawnCount) {
            yield return new WaitForSeconds(spawnFrequency);

            StartCoroutine(Spawn());
        }
    }
}
