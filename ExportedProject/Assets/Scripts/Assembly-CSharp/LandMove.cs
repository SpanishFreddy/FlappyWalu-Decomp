using UnityEngine;

public class LandMove : ObjectMove
{
	private int firstIndex;

	private void Update()
	{
		if (Grapedge.stateInfo != GameState.gameover)
		{
			TGMove();
			if (m_Transform[firstIndex].position.x <= -10f)
			{
				int num = ((firstIndex == 0) ? 1 : 0);
				m_Transform[firstIndex].position = m_Transform[num].position + Vector3.right * 10.5f;
				firstIndex = num;
			}
		}
	}
}
