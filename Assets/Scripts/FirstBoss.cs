using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    public GameObject[] bullRaid;
    public GameObject tankShit;
    private float speed = 5;
    private float spawn1X = -8F;
    private float spawn2X = 0F;
    private float spawnY = 11.84F;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BullRush", 2f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    void BullRush()
    {
        int bullIndex = Random.Range(0, bullRaid.Length); // randomly generates animal index
        Vector3 spawnPos = new Vector3(Random.Range(spawn1X, spawn2X), spawnY, 0f); //randomly generates the position of the object
        Instantiate(bullRaid[bullIndex], spawnPos, bullRaid[bullIndex].transform.rotation); 
}
}

