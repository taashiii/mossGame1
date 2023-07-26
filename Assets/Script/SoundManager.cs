﻿using UnityEngine;
using System;


public class SoundManager : MonoBehaviour
{
	[SerializeField] AudioSource[] audioSources;

	private int _audioIndex = 0;
	private AudioClip[] _audioClips;
	private static SoundManager _main;

	public enum SOUND_TYPE
	{
		Decision,
		Buzzer,
		Select,
		Num
	}
	public static SoundManager GetInstance()
	{
		return _main;
	}

	void Start()
	{
		_main = this;
		_audioClips = new AudioClip[(int)SOUND_TYPE.Num];
		for (int f = 0; f < (int)SOUND_TYPE.Num; f++)
		{
			SOUND_TYPE Type = (SOUND_TYPE)Enum.Parse(typeof(SOUND_TYPE), f.ToString());
			string typename = "Sound/" + Type.ToString();
			_audioClips[f] = (AudioClip)Resources.Load(typename);
		}
	}

	public void Play(SOUND_TYPE sound, float pitch = 1.0f, float volume = 0.4f)
	{
		bool ok = false;
		try
		{
			for (int i = 0; i < _audioClips.Length; i++)
			{
				if (_audioClips[i].name == sound.ToString())
				{
					audioSources[_audioIndex].clip = _audioClips[i];

					audioSources[_audioIndex].volume = volume;
					audioSources[_audioIndex].pitch = pitch;

					audioSources[_audioIndex].Play();
					_audioIndex++;
					if (_audioIndex >= audioSources.Length)
					{
						_audioIndex = 0;
					}
					ok = true;
					break;
				}
			}
		}
		catch
		{
			Debug.LogError("Sound Play Errorr!!!" + sound.ToString());
		}

		if (ok == false)
		{
			Debug.LogError("NOTSOUND!!!" + sound.ToString());
		}
	}

	public void AllStop()
	{
		for (int i = 0; i < audioSources.Length; i++)
		{
			audioSources[i].Stop();
		}
	}
}
