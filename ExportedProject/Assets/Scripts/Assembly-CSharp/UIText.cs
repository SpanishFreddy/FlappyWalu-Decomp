using System.Collections;
using UnityEngine;

public class UIText : Grapedge
{
	private string text;

	public Texture2D fonts;

	public GameObject prefabs;

	private Sprite[] numbers = new Sprite[10];

	private ArrayList list = new ArrayList();

	public Vector3 lastPos = Vector3.zero;

	private readonly float textOffset = 0.375f;

	private void Start()
	{
		for (int i = 0; i < 10; i++)
		{
			numbers[i] = Sprite.Create(fonts, new Rect(i * 24, 0f, 24f, 36f), new Vector2(0.5f, 0.5f), 32f);
		}
	}

	public override void Initialize()
	{
		foreach (object item in list)
		{
			Object.Destroy((GameObject)item);
		}
		list.Clear();
		lastPos = new Vector3(0.375f, 4.88f, -3f);
		TextUpdate();
	}

	public void TextUpdate()
	{
		int num = 0;
		int num2 = Grapedge.score;
		do
		{
			MakeNewText(num);
			GameObject gameObject = (GameObject)list[num];
			gameObject.GetComponent<SpriteRenderer>().sprite = numbers[num2 % 10];
			num2 /= 10;
			num++;
		}
		while (num2 > 0);
	}

	private void MakeNewText(int index)
	{
		if (index < list.Count)
		{
			return;
		}
		foreach (object item in list)
		{
			GameObject gameObject = (GameObject)item;
			lastPos = gameObject.transform.position;
			gameObject.transform.position += Vector3.right * textOffset;
		}
		GameObject value = Object.Instantiate(prefabs, lastPos - Vector3.right * textOffset, Quaternion.identity) as GameObject;
		list.Add(value);
	}
}
