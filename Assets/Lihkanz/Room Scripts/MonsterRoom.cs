using UnityEngine;
using System.Collections;

public class MonsterRoom : MonoBehaviour {

    public Transform[] availableSpawnPoints, availableChestSpawnPoints;
    int amountOfMonsters, amountOfChests;
    public GameObject[] monsters;
    public GameObject chest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        RandomiseValues();
        while (amountOfChests > 0)
        {
            Instantiate(chest, availableChestSpawnPoints[amountOfChests].transform.position, Quaternion.identity);
            amountOfChests--;
        }
        while (amountOfMonsters > 0)
        {
            Instantiate(monsters[Random.Range(0, 1)], availableSpawnPoints[amountOfMonsters].transform.position, Quaternion.identity);
            amountOfMonsters--;
        }
    }

    void OnDisable()
    {
        amountOfChests = 0;
        amountOfMonsters = 0;
    }

    void RandomiseValues()
    {
        amountOfMonsters = Random.Range(0, 2);
        amountOfChests = Random.Range(0, 2);
    }
}
