using UnityEngine;
using System.Collections.Generic;

public class KeyControl : MonoBehaviour
{
	[System.Serializable]
	private class KeySound
	{
		public KeyCode key;
		public AudioSource audioSource;
	}

	[SerializeField] private List<KeySound> keySounds = new List<KeySound>();

	private Dictionary<KeyCode, AudioSource> _keyMap;

	private void Start()
	{
		_keyMap = new Dictionary<KeyCode, AudioSource>();
		foreach (var keySound in keySounds)
		{
			_keyMap[keySound.key] = keySound.audioSource;
		}
	}

	private void Update()
	{
		foreach (var kvp in _keyMap)
		{
			if (Input.GetKeyDown(kvp.Key))
			{
				kvp.Value.Play();
				break;
			}
		}
	}
}