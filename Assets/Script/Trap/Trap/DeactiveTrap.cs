using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveTrap : MonoBehaviour, TriggerTrap
{
	public void trapTrigger()
	{
		gameObject.SetActive(false);
	}
	public void trapInit()
	{
		// Do no thing
	}
}
