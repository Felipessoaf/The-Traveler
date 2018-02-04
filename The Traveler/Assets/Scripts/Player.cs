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

    enum WalkingState
    {
        walking,
        slowing,
        stop
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
    private WalkingState _currentWalkingState;
    private Rigidbody _rb;
    [SerializeField]
    private Animator _animator;
    private float _frac;
    private bool _moving;
    private WaypointDirections _wpd = null;
    #endregion

    #region public variables
    public float Speed;
    public Vector3 Velocity;
    public CamController CamCtrl;
    public static Player PlayerInstance;
    #endregion

    private void Awake()
    {
        PlayerInstance = this;
    }

    // Use this for initialization
    void Start ()
    {
        _rb = transform.parent.gameObject.GetComponent<Rigidbody>();
        _currentState = State.menuWalk;
        _currentDirection = Direction.right;
        _frac = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Velocity = _rb.velocity;

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

    void InitialSteps() {
        _currentState = State.walking;
        CamCtrl.FollowPlayer();
    }

    void Stationary()
    {
        if (GameManager.GameRunnning)
        {
            foreach(Transform t in transform.parent)
            {
                if(t.GetComponent<Drifter>())
                {
                    t.GetComponent<Drifter>().SetMove(false);
                }
            }

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
            foreach (Transform t in transform.parent)
            {
                if (t.GetComponent<Drifter>())
                {
                    t.GetComponent<Drifter>().SetMove(true);
                }
            }
            switch (_currentWalkingState) {
                case WalkingState.walking:
                    _animator.SetBool("Walk", true);
                    _rb.velocity = Vector3.Lerp(Vector3.zero, transform.right * Speed, _frac);
                    _frac += 0.1f;
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        _currentWalkingState = WalkingState.slowing;
                        _frac = 0;
                        Debug.Log("parando");
                    }
                 break;

                case WalkingState.slowing:
                    _rb.velocity = Vector3.Lerp(transform.right * Speed, Vector3.zero, _frac);
                    _frac += 0.1f;
                    if (_frac >= 1f)
                    {
                        _rb.velocity = Vector3.zero;
                        _currentWalkingState = WalkingState.stop;
                        Debug.Log("parado");
                    }
                    break;

                case WalkingState.stop:
                    _animator.SetBool("Walk", false);
                    _currentState = State.stationary;
                    _currentWalkingState = WalkingState.walking;
                    break;

                default:
                    //_currentWalkingState = WalkingState.walking;
                    break;
            }
        }
    }

    void Turning()
    {
        //Debug.Log("Turning");
    }

    void SetStationary()
    {
        //Debug.Log("SetStat");
        CamCtrl.FollowPlayer();
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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.tag == "Waypoint")
        {
            Debug.Log("b");
            _wpd = other.gameObject.GetComponent<WaypointDirections>();
            _currentState = State.stationary;           
        }
    }

}
