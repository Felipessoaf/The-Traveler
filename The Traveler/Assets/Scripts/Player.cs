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

    enum Direction
    {
        up,
        down,
        left,
        right
    }
    #endregion

    #region private variables
    private State _currentState;
    private Direction _currentDirection;
    [SerializeField]
    private Animator _animator;
    #endregion

    #region public variables

    #endregion

    // Use this for initialization
    void Start ()
    {
        _currentState = State.menuWalk;
        _currentDirection = Direction.right;
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
                if(_currentDirection != Direction.right)
                {
                    _animator.SetBool("TurnRight", true);
                    _currentState = State.turning;
                    _currentDirection = Direction.right;
                }
                else
                {
                    _currentState = State.walking;
                }
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_currentDirection != Direction.up)
                {
                    _animator.SetBool("TurnUp", true);
                    _currentState = State.turning;
                    _currentDirection = Direction.up;
                }
                else
                {
                    _currentState = State.walking;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_currentDirection != Direction.left)
                {
                    _animator.SetBool("TurnLeft", true);
                    _currentState = State.turning;
                    _currentDirection = Direction.left;
                }
                else
                {
                    _currentState = State.walking;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_currentDirection != Direction.down)
                {
                    _animator.SetBool("TurnDown", true);
                    _currentState = State.turning;
                    _currentDirection = Direction.down;
                }
                else
                {
                    _currentState = State.walking;
                }
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
        _animator.SetBool("TurnRight", false);
        _currentState = State.walking;
    }
}
