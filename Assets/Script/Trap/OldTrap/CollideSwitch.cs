using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSwitch : MonoBehaviour
{
	public GameObject trap;
	public float dis = 0.2f;
	private void Awake()
	{
		trap = transform.parent.Find("Trap").gameObject;
		if (trap == null)
		{
			Debug.Log("There must be a bug!");
		}
		trap.GetComponent<TriggerTrap>().trapInit();
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject p = other.gameObject;
			RaycastHit2D ray = Physics2D.Raycast(p.transform.position, Vector2.up, dis);
			trap.GetComponent<TriggerTrap>().trapTrigger();
		}
	}
}
