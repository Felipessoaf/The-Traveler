using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _rotateMultiplier;
    
    // Update is called once per frame
    void Update ()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation,Time.deltaTime * _rotateMultiplier);
	}
}
