using System;
using System.Collections.Generic;
using UnityEngine;

public class SkinContainer : MonoBehaviour
{
	[SerializeField] private List<CharacterSkinInfo> _characters;
	[SerializeField] private List<Sprite> _skins;

	private static List<SkinContainer> _instances = new();

	public List<CharacterSkinInfo> Characters => _characters;
	public List<Sprite> Skins => _skins;
	public static SkinContainer Instance => _instances.Count != 0 ? _instances[0] : null;

	public Sprite SkinByCharacterIndex(int index)
	{
		return _skins[_characters[index].SkinIndex];
	}

	private void Awake()
	{
		_instances.Add(this);
	}

	private void Start()
	{
		if (_instances[0] != this)
		{
			_instances.Remove(this);
			Destroy(this.gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}
}