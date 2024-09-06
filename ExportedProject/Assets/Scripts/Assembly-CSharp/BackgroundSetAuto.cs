using System;
using UnityEngine;

public class BackgroundSetAuto : MonoBehaviour
{
	public Sprite[] backGround = new Sprite[2];

	private void Start()
	{
		int hour = DateTime.Now.Hour;
		if (hour >= 18 || hour <= 6)
		{
			GetComponent<SpriteRenderer>().sprite = backGround[1];
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = backGround[0];
		}
		UnityEngine.Object.Destroy(this);
	}
}
