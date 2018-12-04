using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public int Speed;
    public static int oi = 2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * Time.deltaTime * GameController.gameSpeed, Space.World);

        // Destruir quando inimigo passar do z = -3
        if (transform.position.z <= -3)
        {
            Object.Destroy(this.gameObject);
        }

        if (GameController.highSpeed)
        {
            Object.Destroy(this.gameObject);
        }

    }
}