using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _rotateMultiplier;
    private bool _followPlayer;
    
    //TODO: follow player
    public void FollowPlayer()
    {
        _followPlayer = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if(_followPlayer)
        {
            GetComponent<Rigidbody>().velocity = _target.parent.gameObject.GetComponent<Rigidbody>().velocity;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation,Time.deltaTime * _rotateMultiplier);
	}
}
