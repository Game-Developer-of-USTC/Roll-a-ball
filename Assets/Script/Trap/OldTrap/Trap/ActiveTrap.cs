using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrap : MonoBehaviour, TriggerTrap
{
	public float waitTime;
	public void trapInit()
	{
		gameObject.SetActive(false);
	}
	public void trapTrigger()
	{
		Invoke("internalTrigger", waitTime);

	}

	void internalTrigger()
	{
		gameObject.SetActive(true);
	}
}
