using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinChangerUI : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _dummy;
	[SerializeField] private TMP_Text _characterName;
	[SerializeField] private Button _nextButton;
	[SerializeField] private Button _previewButton;
	[SerializeField] private Button _nextSkin;
	[SerializeField] private Button _previewSkin;

	private int _currentCharacter = 0;

	public int CurrentCharacterIndex
	{
		get
		{
			return _currentCharacter;
		}
		set
		{
			_currentCharacter = value;
			if (_currentCharacter >= SkinContainer.Instance.Characters.Count)
			{
				_currentCharacter = SkinContainer.Instance.Characters.Count - 1;
			}
			if (_currentCharacter < 0)
			{
				_currentCharacter = 0;
			}
			UpdateDummy();
		}
	}

	public int CurrentSkinIndex
	{
		get
		{
			return SkinContainer.Instance.Characters[_currentCharacter].SkinIndex;
		}
		set
		{
			if (value >= SkinContainer.Instance.Skins.Count)
			{
				SkinContainer.Instance.Characters[_currentCharacter].SkinIndex = SkinContainer.Instance.Skins.Count - 1;
			}
			else if (value < 0)
			{
				SkinContainer.Instance.Characters[_currentCharacter].SkinIndex = 0;
			}
			else
			{
				SkinContainer.Instance.Characters[_currentCharacter].SkinIndex = value;
			}
			UpdateDummy();
		}
	}

	private void UpdateDummy()
	{
		_dummy.sprite = SkinContainer.Instance.Skins[SkinContainer.Instance.Characters[_currentCharacter].SkinIndex];
		_dummy.color = SkinContainer.Instance.Characters[_currentCharacter].Color;
		_characterName.text = SkinContainer.Instance.Characters[_currentCharacter].Name;
	}

	private void Awake()
	{
		UpdateDummy();
	}

	private void OnEnable()
	{
		_nextButton.onClick.AddListener(NextCharacter);
		_previewButton.onClick.AddListener(PreviewCharacter);
		_nextSkin.onClick.AddListener(NextSkin);
		_previewSkin.onClick.AddListener(PreviewSkin);
	}

	private void OnDisable()
	{
		_nextButton.onClick.RemoveListener(NextCharacter);
		_previewButton.onClick.RemoveListener(PreviewCharacter);
		_nextSkin.onClick.RemoveListener(NextSkin);
		_previewSkin.onClick.RemoveListener(PreviewSkin);
	}

	public void PreviewCharacter()
	{
		CurrentCharacterIndex--;
	}

	public void NextCharacter()
	{
		CurrentCharacterIndex++;
	}

	private void PreviewSkin()
	{
		CurrentSkinIndex--;
	}

	private void NextSkin()
	{
		CurrentSkinIndex++;
	}
}