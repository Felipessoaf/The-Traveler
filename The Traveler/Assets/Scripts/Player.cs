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
                MenuWalk();
                break;
            case State.stationary:
                Stationary();
                break;
            case State.walking:
                Walking();
                break;
            case State.turning:
                Turning();
                break;
            default:
                break;
        }
	}

    void MenuWalk()
    {
        
    }

    void Stationary()
    {
        if (GameManager.GameRunnning)
        {
            Debug.Log("Stationary");
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                _currentState = State.walking;
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                _animator.SetBool("TurnUp", true);
                _currentState = State.turning;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _animator.SetBool("TurnLeft", true);
                _currentState = State.turning;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _animator.SetBool("TurnDown", true);
                _currentState = State.turning;
            }
        }
    }

    void Walking()
    {
        if (GameManager.GameRunnning)
        {
            _animator.SetBool("Walk", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _animator.SetBool("Walk", false);
                _currentState = State.stationary;
            }
        }
    }

    void Turning()
    {
        Debug.Log("Turning");
    }

    void SetStationary()
    {
        Debug.Log("SetStat");
        _currentState = State.stationary;
    }

    void SetWalking()
    {
        _animator.SetBool("TurnUp", false);
        _animator.SetBool("TurnLeft", false);
        _animator.SetBool("TurnDown", false);
        _currentState = State.walking;
    }
}
