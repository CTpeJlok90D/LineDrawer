using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] private int _levelLoad;

	public void Load()
	{
		SceneManager.LoadScene(_levelLoad);
	}
}
