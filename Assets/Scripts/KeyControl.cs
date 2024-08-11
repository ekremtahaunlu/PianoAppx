using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class KeyControl : MonoBehaviour
{
	[System.Serializable]
	private class KeySound
	{
		public KeyCode key;
		public AudioSource audioSource;
		public SpriteRenderer spriteRenderer;
	}

	[SerializeField] private List<KeySound> keySounds = new List<KeySound>();
	[SerializeField] private float colorChangeDuration = 0.1f;

	private Dictionary<KeyCode, KeySound> keyMap;

	private void Start()
	{
		keyMap = new Dictionary<KeyCode, KeySound>();
		foreach (var keySound in keySounds)
		{
			keyMap[keySound.key] = keySound;
		}
	}

	private void Update()
	{
		foreach (var kvp in keyMap)
		{
			if (Input.GetKeyDown(kvp.Key))
			{
				PlaySoundAndAnimate(kvp.Value);
				break;
			}
		}
	}

	private void PlaySoundAndAnimate(KeySound keySound)
	{
		keySound.audioSource.Play();
		
		Color originalColor = keySound.spriteRenderer.color;
		Sequence sequence = DOTween.Sequence();
        
		sequence.Append(keySound.spriteRenderer.DOColor(Color.red, colorChangeDuration))
			.Append(keySound.spriteRenderer.DOColor(originalColor, colorChangeDuration));
	}
}