using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveTrap : MonoBehaviour, TriggerTrap
{
	public float waitTime;
	public void trapInit()
	{
		// Do no thing
	}
	public void trapTrigger()
	{
		Invoke("internalTrigger", waitTime);

	}

	void internalTrigger()
	{
		gameObject.SetActive(false);
	}
}
