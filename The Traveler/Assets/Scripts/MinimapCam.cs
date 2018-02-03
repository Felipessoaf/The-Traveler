using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCam : MonoBehaviour {

    public Transform Player;

	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 newPos = Player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
	}
}
