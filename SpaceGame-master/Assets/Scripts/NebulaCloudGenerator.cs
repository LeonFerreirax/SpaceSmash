using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaCloudGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] nebulasCloud;

    private float temp = 60.0f;
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
                int nebulasEsco = Random.Range(0, nebulasCloud.Length);
                center = new Vector3(0, -4.2f, 15000f);
                vector3s[0] = center;
                Instantiate(nebulasCloud[nebulasEsco], vector3s[0], Quaternion.identity);
                time = Time.time;
            }

        }
    }

}
