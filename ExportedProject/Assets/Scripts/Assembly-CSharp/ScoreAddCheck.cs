using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScoreAddCheck : Grapedge
{
	private RaycastHit2D hitInfo;

	private UIText scoreManger;

	private bool enter;

	private AudioSource m_Audio;

	private void Start()
	{
		scoreManger = GameObject.Find("ScoreManger").GetComponent<UIText>();
		m_Audio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		hitInfo = Physics2D.Linecast(base.transform.position + Vector3.up * 5f, base.transform.position + Vector3.up * 11f, 1 << LayerMask.NameToLayer("Player"));
		if (hitInfo.collider == null)
		{
			enter = false;
		}
		else if (!enter && hitInfo.collider.tag == "Player")
		{
			m_Audio.Play();
			Grapedge.score++;
			scoreManger.TextUpdate();
			enter = true;
		}
	}
}
