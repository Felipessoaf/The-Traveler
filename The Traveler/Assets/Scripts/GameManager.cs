using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region private variables
    
    #endregion

    #region public variables
    public static bool GameRunnning = false;
    #endregion

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartGame()
    {
        Debug.Log("StartGame");
        GameRunnning = true;
    }
}
