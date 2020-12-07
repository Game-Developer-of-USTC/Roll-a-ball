using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSwitch : MonoBehaviour
{
	public GameObject trap;
	private void Awake()
	{
		trap = transform.parent.Find("Trap").gameObject;
		if (trap == null)
		{
			Debug.Log("There must be a bug!");
		}
		trap.GetComponent<CollidTrap>().trapInit();
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (other.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
				trap.GetComponent<CollidTrap>().trapTrigger();
		}
	}
}
