using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartone : MonoBehaviour {

    public Button play;
    public Text highscore;



    // Use this for initialization
    void Start () {

        highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        play.onClick.AddListener(TaskOnClick);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
