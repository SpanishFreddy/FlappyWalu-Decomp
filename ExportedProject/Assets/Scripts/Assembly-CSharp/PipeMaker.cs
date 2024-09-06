using UnityEngine;

public class PipeMaker : Grapedge
{
	private GameObject[] pipes = new GameObject[3];

	public GameObject prefabs;

	public float waitTime = 3f;

	private float m_Timer;

	private bool inited;

	private int m_LastGameObjectIndex;

	private int index;

	private void Update()
	{
		if (Grapedge.stateInfo == GameState.gameover)
		{
			Object.Destroy(base.gameObject);
		}
		if (!inited)
		{
			m_Timer += Time.deltaTime;
			if (waitTime < m_Timer)
			{
				for (int i = 0; i < pipes.Length; i++)
				{
					float x = ((i != 0) ? (pipes[i - 1].transform.position.x + 5f) : 6f);
					pipes[i] = Object.Instantiate(prefabs, new Vector3(x, (float)Random.Range(-2, 5) + 0.5f, 0f), Quaternion.identity) as GameObject;
				}
				m_LastGameObjectIndex = pipes.Length - 1;
				inited = true;
			}
		}
		else if (pipes[index].transform.position.x <= -5.5f)
		{
			pipes[index].transform.position = new Vector3(pipes[m_LastGameObjectIndex].transform.position.x + 5f, (float)Random.Range(-2, 5) + 0.5f, -1f);
			m_LastGameObjectIndex = index;
			index = ((index + 1 < pipes.Length) ? (index + 1) : 0);
		}
	}
}
