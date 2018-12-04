using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    public Button play;
    public Text highscore;
    public Text score;
    public Text newhigh;


    // Use this for initialization
    void Start () {
        newhigh.enabled = false;
        play.onClick.AddListener(TaskOnClick);
        
        score.text = PlayerPrefs.GetInt("score", 0).ToString();

        if(PlayerPrefs.GetInt("score", 0) > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score", 0));
            newhigh.enabled = true;
        }

        highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
