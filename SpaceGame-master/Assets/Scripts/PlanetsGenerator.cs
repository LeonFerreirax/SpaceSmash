using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject[] planets;

    private float temp = 20.0f;
    private float time;


    Vector3[] vector3s = new Vector3[2];
    Vector3 right;
    Vector3 left;

    [SerializeField]
    private bool startGerate = false;
    // Use this for initialization
    void Start()
    {
        time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.onGame)
        {
            if ((Time.time >= time + (temp / GameController.gameSpeed)))
            {
                int planetPos = Random.Range(0, planets.Length);
                float randomXRight = Random.Range(600f, 11020f);
                float randomY = Random.Range(-730f, 2085f);
                float randomXLeft = Random.Range(-600f, -11020f);
                right = new Vector3(randomXRight, randomY, 15000f);
                left = new Vector3(randomXLeft, randomY, 15000f);
                vector3s[0] = right;
                vector3s[1] = left;

                Instantiate(planets[planetPos], vector3s[Random.Range(0, 2)], Quaternion.identity);
                time = Time.time;
            }

        }
    }
}

