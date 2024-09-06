public class DebugInfo : Grapedge
{
	public GameState state;

	public int scores;

	private void Update()
	{
		state = Grapedge.stateInfo;
		scores = Grapedge.score;
	}
}
