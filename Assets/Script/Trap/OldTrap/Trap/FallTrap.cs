﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour, TriggerTrap
{
    // Start is called before the first frame update
    public float waitTime;
    public RigidbodyType2D initType = RigidbodyType2D.Static;
    public RigidbodyType2D afterType = RigidbodyType2D.Dynamic;
    public void trapInit()
    {
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = initType;
    }

    public void trapTrigger()
    {
        Invoke("changeType", waitTime);
    }

    void changeType()
    {
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = afterType;
    }
}
