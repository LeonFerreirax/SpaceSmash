using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detrito : MonoBehaviour
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
        int randomRotate = Random.Range(5, 6);
        //Andar ao contrário no eixo Z em relação ao mundo
        // E girar com relação a si próprio
        transform.Translate(Vector3.back * Time.deltaTime * GameController.gameSpeed, Space.World);
        transform.Rotate(-Vector3.up * randomRotate * 10 * Time.deltaTime, Space.Self);


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