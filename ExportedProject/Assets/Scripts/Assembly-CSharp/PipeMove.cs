using UnityEngine;

public class PipeMove : ObjectMove
{
	private void Update()
	{
		if (Grapedge.stateInfo == GameState.gameover)
		{
			BoxCollider2D[] componentsInChildren = GetComponentsInChildren<BoxCollider2D>();
			BoxCollider2D[] array = componentsInChildren;
			foreach (BoxCollider2D boxCollider2D in array)
			{
				boxCollider2D.enabled = false;
			}
		}
		else
		{
			TGMove();
		}
	}
}
