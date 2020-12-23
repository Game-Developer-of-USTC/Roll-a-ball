using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
	public Collider2D coll;
	public GameObject trap;
	// Start is called before the first frame update
	void Awake()
	{
		coll = GetComponent<Collider2D>();
		trap = transform.parent.Find("Trap").gameObject;
		trap.GetComponent<TriggerTrap>().trapInit();
	}

	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			trap.GetComponent<TriggerTrap>().trapTrigger();
			gameObject.SetActive(false);
		}
	}
}
