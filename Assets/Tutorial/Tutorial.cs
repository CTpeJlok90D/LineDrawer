using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
	private void OnEnable()
	{
		InputSingletone.Instance.Drawing.Draw.started += OnDrawStarted;
	}

	private void OnDisable()
	{
		InputSingletone.Instance.Drawing.Draw.started -= OnDrawStarted;
	}

	private void OnDrawStarted(InputAction.CallbackContext obj)
	{
		Destroy(gameObject);
	}
}
