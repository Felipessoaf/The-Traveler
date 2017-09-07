using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region enum
    enum State
    {
        menuWalk,
        stationary,
        walking,
        turning
    }
    #endregion

    #region private variables
    private State _currentState;
    [SerializeField]
    private Animator _animator;
    #endregion

    #region public variables

    #endregion

    // Use this for initialization
    void Start ()
    {
        _currentState = State.menuWalk;
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch(_currentState)
        {
            case State.menuWalk:
                break;
            case State.stationary:
                break;
            case State.walking:
                break;
            case State.turning:
                break;
            default:
                break;
        }
	}
}
