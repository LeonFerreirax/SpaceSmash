using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Speed that the player moves from one lane to another
    public float swipeSpeed;
    public int speed;
    public float rotateSpeed;
    private int h = Screen.height;
    private int w = Screen.width;
    public float HoverdegreesPerSecond = 15.0f;
    public float Hoveramplitude = 0.5f;
    public float Hoverfrequency = 1f;
    Vector3 center;
    Vector3 right;
    Vector3 left;
    Vector3[] positions = new Vector3[3];
    private int actualposition = 1;
    Quaternion rot;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    public AudioSource source;
    public AudioClip moeda;
    public AudioClip shift;



    // Use this for initialization
    void Start () {
        //print(transform.rotation);
        center = transform.position;
        right = new Vector3(0.8f, 0.5f, 0);
        left = new Vector3(-0.8f, 0.5f, 0);
        rot = transform.rotation;
        positions[0] = left;
        positions[1] = center;
        positions[2] = right;
        posOffset = transform.position;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogo estiver rolando
        if (GameController.onGame)
        {
            // Com esse passo aqui
            float step = speed * Time.deltaTime;
            float stepRot = rotateSpeed * Time.deltaTime;

            //Esses ifs decidem pra qual das posições definidas a nave vai com base na que ela está
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (actualposition <= 0)
                {

                }

                else
                {
                    actualposition = actualposition - 1;
                    rot.z = -0.174533f;
                    source.PlayOneShot(shift, 0.7f);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (actualposition >= 2)
                {

                }

                else
                {
                    actualposition = actualposition + 1;
                    source.PlayOneShot(shift, 0.7f);
                }

            }
            // Define pra onde ela vai girar
            if (actualposition == 0) { rot.z = -0.174533f; }
            if (actualposition == 1) { rot.z = 0.0f; }
            if (actualposition == 2) { rot.z = 0.174533f; }

            //print(actualposition);


            // The step size is equal to speed times frame time.


            // Move ela pro lugar e gira ela
            transform.position = Vector3.Lerp(transform.position, positions[actualposition], step);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, stepRot);

            // Adiciona a vibração
            tempPos = transform.position;
            if (GameController.highSpeed)
            {
                tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Hoverfrequency * Random.Range(2f, 5.0f) + Random.Range(0.0f, 1.0f)) * Hoveramplitude * Random.Range(1.5f, 1.7f);
                tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * Hoverfrequency * Random.Range(2f, 5.0f) + Mathf.PI / 2 + Random.Range(0.0f, 1.0f)) * Hoveramplitude * Random.Range(1.5f, 1.7f);
            }

            else
            {
                tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Hoverfrequency * Random.Range(1f, 3.0f) + Random.Range(0.0f, 1.0f)) * Hoveramplitude;
                tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * Hoverfrequency * Random.Range(1.0f, 3.0f) + Mathf.PI / 2 + Random.Range(0.0f, 1.0f)) * Hoveramplitude;
            }
            

            transform.position = tempPos;

        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.gameObject.tag == "Enemy")
        {
            GameController.onGame = false;
        }


    }

    private void OnTriggerEnter(Collider collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "Coin")
        {
            Object.Destroy(collisionInfo.gameObject);
            GameController.coins += 1;
            print("COINS: " + GameController.coins);
            source.clip = moeda;
            source.Play();
            GameController.score += 10;
        }
    }


}

