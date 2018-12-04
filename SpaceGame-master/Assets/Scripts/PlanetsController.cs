using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsController : MonoBehaviour {


    [SerializeField]
    private float _speed = 100.0f;

    [SerializeField]
    private bool startGerate = false;
    // Use this for initialization
    void Start () {
        int tamPlanet = Random.Range(50, 90);
        transform.localScale = new Vector3(tamPlanet, tamPlanet, tamPlanet);
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _speed, Space.World);

        if (transform.position.z < -50)
        {
            Destroy(this.gameObject);
        }
    }
}
