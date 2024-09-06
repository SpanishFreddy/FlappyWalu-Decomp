using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Grapedge
{
	public Vector3 playPosition;

	public Vector3 titlePosition;

	private Transform m_Transform;

	private Rigidbody2D m_Rigidbody;

	private SpriteRenderer m_Renderer;

	private int m_BirdColor;

	private float m_AnimTimer;

	private int m_CurFrame;

	public float perFrameTime = 0.2f;

	public Sprite[] birdSprite;

	public float velocity = 9.165f;

	private float m_RotationTimer;

	private float m_RotationWanted;

	private AudioSource m_Audio;

	public AudioClip wings;

	public AudioClip die;

	private float m_ShmTimer;

	private void Start()
	{
		m_Transform = base.transform;
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Renderer = GetComponent<SpriteRenderer>();
		UnityEngine.Random.seed = Environment.TickCount;
		m_Audio = GetComponent<AudioSource>();
		Initialize();
	}

	public override void Initialize()
	{
		m_Transform.position = ((Grapedge.stateInfo != 0) ? playPosition : titlePosition);
		m_Transform.rotation = Quaternion.identity;
		m_Rigidbody.isKinematic = true;
		m_BirdColor = UnityEngine.Random.Range(0, 3);
		m_AnimTimer = 0f;
		m_ShmTimer = 0f;
	}

	private void Update()
	{
		UpdateAnimation();
		UpdateSimpleHarmonicMotion();
		RotationUpdate();
		UpdateGame();
	}

	public void StartPlayer()
	{
		m_Rigidbody.isKinematic = false;
		Grapedge.stateInfo = GameState.playing;
	}

	private void UpdateGame()
	{
		if (Grapedge.stateInfo == GameState.playing && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
		{
			m_Audio.PlayOneShot(wings);
			UpdateFlappyBird();
		}
	}

	public void UpdateFlappyBird()
	{
		m_Rigidbody.velocity = Vector2.up * velocity;
		m_RotationWanted = 25f;
		m_RotationTimer = 0f;
	}

	private void RotationUpdate()
	{
		if (Grapedge.stateInfo == GameState.playing || Grapedge.stateInfo == GameState.gameover)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(Vector3.forward * m_RotationWanted), Time.deltaTime * 5f);
			m_RotationTimer += Time.deltaTime;
			if (m_RotationTimer >= 0.64f)
			{
				m_RotationTimer = 0f;
				m_RotationWanted = -90f;
			}
		}
	}

	private void UpdateAnimation()
	{
		if (Grapedge.stateInfo != GameState.gameover)
		{
			m_AnimTimer += Time.deltaTime;
			if (m_AnimTimer >= perFrameTime)
			{
				m_AnimTimer -= perFrameTime;
				m_Renderer.sprite = birdSprite[m_BirdColor * 3 + m_CurFrame];
				m_CurFrame = ((m_CurFrame + 1 < 3) ? (m_CurFrame + 1) : 0);
			}
		}
	}

	private void UpdateSimpleHarmonicMotion()
	{
		bool flag = Grapedge.stateInfo == GameState.title;
		bool flag2 = Grapedge.stateInfo == GameState.get_ready;
		if (flag || flag2)
		{
			m_ShmTimer += Time.deltaTime;
			float num = 0.03f * Mathf.Cos(10f * m_ShmTimer);
			base.transform.position = ((!flag) ? playPosition : titlePosition) + Vector3.up * num;
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (Grapedge.stateInfo != GameState.gameover && !(col.collider.tag != "Failed"))
		{
			if (col.collider.name != "Land_1" || col.collider.name != "Land_2")
			{
				UpdateFlappyBird();
				m_RotationWanted = -90f;
			}
			GameObject.Find("Fade").GetComponent<Animator>().Play("Flash");
			m_Audio.PlayOneShot(die);
			Grapedge.stateInfo = GameState.gameover;
		}
	}
}
