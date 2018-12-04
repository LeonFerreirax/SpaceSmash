using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] nebulas;

    private float temp = 100.0f;
    private float time;


    Vector3[] vector3s = new Vector3[1];
    Vector3 center;

    // Use this for initialization
    void Start()
    {
        time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.onGame)
        {
            if ((Time.time >= time + (temp / GameController.gameSpeed)))
            {
                int nebulasEsco = Random.Range(0, nebulas.Length);
                center = new Vector3(0, 0, 15000f);
                vector3s[0] = center;
                Instantiate(nebulas[nebulasEsco], vector3s[0], Quaternion.identity);
                time = Time.time;
            }

        }
    }

}
