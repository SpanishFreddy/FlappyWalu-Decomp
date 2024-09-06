using UnityEngine;

public class ReloadGame : Grapedge
{
	private bool has_DeleteTitle;

	private AudioSource m_Audio;

	private void Start()
	{
		m_Audio = GetComponent<AudioSource>();
	}

	public override void Initialize()
	{
		if (!has_DeleteTitle)
		{
			Object.Destroy(GameObject.Find("Title"));
			has_DeleteTitle = true;
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Pipe");
		GameObject[] array2 = array;
		foreach (GameObject obj in array2)
		{
			Object.Destroy(obj);
		}
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().Initialize();
		GameObject.Find("ButtonManger").GetComponent<UIButton>().buttonNormal.SetActive(false);
		GameObject.Find("text_ready").GetComponent<Animator>().Play("ready_in");
		Grapedge.score = 0;
		GameObject.Find("ScoreManger").GetComponent<UIText>().Initialize();
		Grapedge.stateInfo = GameState.get_ready;
	}

	public void GameOver()
	{
		m_Audio.Play();
		GameObject.Find("ButtonManger").GetComponent<UIButton>().buttonNormal.SetActive(true);
	}
}
