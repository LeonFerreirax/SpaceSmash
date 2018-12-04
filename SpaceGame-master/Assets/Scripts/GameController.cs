using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static bool onGame = true;
    public float speed = 1;
    public static float gameSpeed;
    float time;
    public static bool highSpeed = false;
    public static float lastspeed = 0;
    public static int score;
    public static int coins;
    public int coinsToHighSpeed = 40;
    public Text coinText;
    public Text scoreText;
    float timePoint;
    public AudioClip highspeedPìck;
    public AudioSource source;

    // Use this for initialization
    void Start () {
        time = Time.time;
        timePoint = Time.time;
        gameSpeed = speed;
        lastspeed = speed;
        score = 0;
        coins = 0;
        source = GetComponent<AudioSource>();


    }
	
	// Update is called once per frame
	void Update () {

        PlayerPrefs.SetInt("score", score);

        coinText.text = coins.ToString();
        scoreText.text = score.ToString();

        if (Time.time >= time + 7.5f && gameSpeed < 50 && !highSpeed)
        {
            gameSpeed = gameSpeed + 0.125f;
            print("Game Speed is" + gameSpeed);
            time = Time.time;
            lastspeed = gameSpeed;
        }

        if(Time.time >= timePoint + 2f/gameSpeed)
        {
            score += 1;
            timePoint = Time.time;
        }

        if (onGame == false)
        {
            onGame = true;
            SceneManager.LoadScene("EndScreenScene");
        }

        if (highSpeed)
        {
            gameSpeed = 10f;
        }

        if((coins % coinsToHighSpeed) == 0 && coins != 0)
        {
            print("GOT HERE");
            //source.clip = highspeedPìck;

            if (!source.isPlaying)
            {
                source.PlayOneShot(highspeedPìck, 0.7f);
            }
            
            highSpeed = true;
           
        }

	}
}
