using UnityEngine;

public class CharacterSkinLoader : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _renderer;
	[SerializeField] private int _characterIndex;

	private void Awake()
	{
		if (SkinContainer.Instance == null)
		{
			return;
		}
		_renderer.sprite = SkinContainer.Instance.SkinByCharacterIndex(_characterIndex);
	}
}