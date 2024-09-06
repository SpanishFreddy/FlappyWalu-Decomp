using UnityEngine;

public class GameManger : Grapedge
{
	public GameObject pipeMakerPrefabs;

	private void Update()
	{
		if (Grapedge.stateInfo == GameState.get_ready)
		{
			GetReady();
		}
	}

	private void GetReady()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			GameObject.Find("text_ready").GetComponent<Animator>().Play("play");
			GameObject.FindWithTag("Player").GetComponent<PlayerController>().StartPlayer();
			Object.Instantiate(pipeMakerPrefabs);
		}
	}
}
