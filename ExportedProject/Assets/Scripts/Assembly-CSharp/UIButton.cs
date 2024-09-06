using UnityEngine;

public class UIButton : MonoBehaviour
{
	private AudioSource m_Audio;

	private GameObject m_LastButton;

	public GameObject buttonNormal;

	private void OnButtonPlayClick()
	{
		GameObject.Find("Fade").GetComponent<Animator>().Play("Fade");
	}

	private void OnButtonExitClick()
	{
		Application.Quit();
	}

	private void OnButtonGrapeClick()
	{
		Application.OpenURL("http://bbs.u-pt.pw/forum.php");
	}

	private void Start()
	{
		buttonNormal = GameObject.Find("ButtonSprite");
		m_Audio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D raycastHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (raycastHit2D.collider != null)
			{
				if (raycastHit2D.collider.tag != "Button")
				{
					return;
				}
				raycastHit2D.collider.transform.position += new Vector3(1f / 32f, -1f / 32f, 0f);
				m_LastButton = raycastHit2D.collider.gameObject;
				if (raycastHit2D.collider.name == "button_play")
				{
					m_Audio.Play();
					OnButtonPlayClick();
				}
				else if (raycastHit2D.collider.name == "button_grapedge")
				{
					OnButtonGrapeClick();
				}
				else if (raycastHit2D.collider.name == "button_exit")
				{
					OnButtonExitClick();
				}
			}
		}
		if (Input.GetMouseButtonUp(0) && m_LastButton != null)
		{
			m_LastButton.transform.position -= new Vector3(1f / 32f, -1f / 32f, 0f);
			m_LastButton = null;
		}
	}
}
