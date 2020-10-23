using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;
	public AudioMixerGroup mixerGroup;

	public int currentlvl;

	public Sound[] sounds;

	void Awake()
	{
		 
	
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	private void Start()
	{
		
			Play("Theme");
		
	}
	private void Update()
	{
		
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		
		s.source.Stop();
	}
	public void PlayOnObject(int i, GameObject attached, string sound)
	{
		
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (i == 1)
		{

			s.source = attached.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			attached.GetComponent<AudioSource>().Play();
		}
		if (i == 0)
		{
			foreach (AudioSource stopAll in attached.GetComponents<AudioSource>())
			{
		
				stopAll.Stop();
			}
		}
		
	}
}
