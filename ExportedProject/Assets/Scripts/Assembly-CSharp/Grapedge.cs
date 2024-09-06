using UnityEngine;

public class Grapedge : MonoBehaviour
{
	public enum GameState
	{
		title = 0,
		get_ready = 1,
		playing = 2,
		gameover = 3
	}

	public static GameState stateInfo;

	public static int score = 123456789;

	public virtual void Initialize()
	{
	}
}
