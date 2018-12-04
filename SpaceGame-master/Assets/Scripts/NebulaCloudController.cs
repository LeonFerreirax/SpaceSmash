using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaCloudController : MonoBehaviour {

    [SerializeField]
    private float _speed = 80.0f;

    // Use this for initialization
    void Start()
    {
        int tamNebula = Random.Range(1, 10);
        transform.localScale = new Vector3(tamNebula, tamNebula, tamNebula);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _speed, Space.World);

        if (transform.position.z < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
