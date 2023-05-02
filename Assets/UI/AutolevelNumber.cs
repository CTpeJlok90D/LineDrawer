using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class AutolevelNumber : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private string _prefix = "Level: ";

	private void Awake()
	{
		_text.text = _prefix + SceneManager.GetActiveScene().buildIndex;
		DestroyImmediate(this);
	}
}
