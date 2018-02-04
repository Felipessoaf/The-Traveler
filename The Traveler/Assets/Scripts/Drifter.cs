using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifter : MonoBehaviour {

    public Animator Anim;
    public bool Unlocked;

    public void SetEvent()
    {
        if (Unlocked)
        {
            Anim.SetTrigger("event");
        }
    }

    public void SetMove(bool moving)
    {
        Anim.SetBool("moving", moving);
    }
}
