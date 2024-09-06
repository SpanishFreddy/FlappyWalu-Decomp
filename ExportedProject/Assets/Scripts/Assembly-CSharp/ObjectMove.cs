using UnityEngine;

public class ObjectMove : Grapedge
{
	public Vector3 directionNormal;

	public float speed;

	public Transform[] m_Transform;

	protected void TGMove()
	{
		Transform[] array = m_Transform;
		foreach (Transform transform in array)
		{
			transform.Translate(directionNormal * speed * Time.deltaTime);
		}
	}
}
