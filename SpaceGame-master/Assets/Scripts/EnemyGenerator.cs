using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    public GameObject[] enemyObjects = new GameObject[6];
    public GameObject coin;

    Vector3[] positions = new Vector3[3];
    Vector3 center;
    Vector3 right;
    Vector3 left;
    float time;
    float coinTime;
    int tick = 0;
    bool generateCoin = true;
    bool generatingNow = false;
    int howmanyCoins = 0;
    int howlongbeforeother = 0;
    int posicaotickmoeda = 0;
    int highSpeedtick = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        center = new Vector3(0f, 0f, 15f);
        right = new Vector3(0.8f, 0.5f, 15f);
        left = new Vector3(-0.8f, 0.5f, 15f);
        positions[0] = left;
        positions[1] = center;
        positions[2] = right;
        time = Time.time - 5f;
        coinTime = Time.time - 5f;

    }

    void Update()
    {
        
        float timeBetween = 1.5f;

        if (GameController.onGame)
        {
            if ((Time.time >= time + (timeBetween / GameController.gameSpeed)))
            {
                if (!GameController.highSpeed)
                { 
                    if (generateCoin)
                    {
                        generateCoin = false;
                        generatingNow = true;
                        howmanyCoins = Random.Range(3, 8);
                        howlongbeforeother = Random.Range(4, 15);
                        posicaotickmoeda = 0;
                    }

                    if (posicaotickmoeda > (howmanyCoins + howlongbeforeother) - 1)
                    {
                        generateCoin = true;
                    }



                    if (tick == 0)
                    {
                        int emptyPosition = Random.Range(0, 3);
                        for (int i = 0; i < 3; i++)
                        {
                            if (i != emptyPosition)
                            {
                                int enemyPos = Random.Range(0, enemyObjects.Length);
                                Instantiate(enemyObjects[enemyPos], positions[i], Quaternion.identity);
                            }
                        }


                        if (posicaotickmoeda > howlongbeforeother)
                        {
                            int coinPos = Random.Range(0, 3);
                            Instantiate(coin, positions[emptyPosition], Quaternion.identity);
                        }

                        //time = Time.time;
                    }

                    else
                    {
                        if (posicaotickmoeda > howlongbeforeother)
                        {
                            int coinPos = Random.Range(0, 3);
                            Instantiate(coin, positions[coinPos], Quaternion.identity);
                        }

                    }

                    tick = tick + 1;
                    posicaotickmoeda = posicaotickmoeda + 1;

                    if (tick == 4)
                    {
                        tick = 0;
                    }

                    time = Time.time;
                }

                else
                {   
                    int coinPos = Random.Range(0, 3);
                    Instantiate(coin, positions[coinPos], Quaternion.identity);
                    highSpeedtick = highSpeedtick + 1;
                    time = Time.time;

                    if (highSpeedtick >= 50)
                    {
                        GameController.highSpeed = false;
                        GameController.gameSpeed = GameController.lastspeed;
                        highSpeedtick = 0;
                        
                    }

                }

            }

        }
    }
}