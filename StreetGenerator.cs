using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetGenerator : MonoBehaviour {

    public GameObject[] houseUnits;
    public int houseCount;
    public bool weightedSpawning;
    public float weight1;
    public float weight2;
    public float weight3;
    public int weight1Bound;
    public int weight2Bound;
    public int weight3Bound;


    private int houseTypes;

	// Use this for initialization
	void Start () {
        houseTypes = houseUnits.GetLength(0);
        if (weightedSpawning) {
            spawnWeightedHouses(houseCount);
        } else {
            spawnHouses(houseCount);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnHouses(int houses) {
        if(houses == 0) {
            return;
        }
        GameObject unit = Instantiate(houseUnits[Random.Range(0, houseTypes)], new Vector3(21 * (houses - 1), 0, 0), Quaternion.identity) as GameObject;
        unit.transform.parent = transform;
        spawnHouses(houses - 1);
    }

    void spawnWeightedHouses (int houses) {
        if (houses == 0) {
            return;
        }
        float random = Random.Range(0f, 1f);
        if (random <= weight1) {
            GameObject unit = Instantiate(houseUnits[Random.Range(0, weight1Bound)], new Vector3(21 * (houses - 1), 0, 0), Quaternion.identity) as GameObject;
            unit.transform.parent = transform;
            spawnHouses(houses - 1);
        } else if (random <= weight2) {
            GameObject unit = Instantiate(houseUnits[Random.Range(weight1Bound, weight2Bound)], new Vector3(21 * (houses - 1), 0, 0), Quaternion.identity) as GameObject;
            unit.transform.parent = transform;
            spawnHouses(houses - 1);
        } else if (random <= weight3) {
            GameObject unit = Instantiate(houseUnits[Random.Range(weight2Bound, weight3Bound)], new Vector3(21 * (houses - 1), 0, 0), Quaternion.identity) as GameObject;
            unit.transform.parent = transform;
            spawnHouses(houses - 1);
        } else {
            GameObject unit = Instantiate(houseUnits[Random.Range(weight3Bound, houseTypes)], new Vector3(21 * (houses - 1), 0, 0), Quaternion.identity) as GameObject;
            unit.transform.parent = transform;
            spawnHouses(houses - 1);
        }
    }
}
