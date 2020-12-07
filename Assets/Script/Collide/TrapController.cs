using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, CollidTrap
{
	public void trapTrigger()
	{
		gameObject.SetActive(true);
	}
	public void trapInit()
	{
		gameObject.SetActive(false);
	}
}
