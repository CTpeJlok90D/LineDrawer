using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDrawing : MonoBehaviour
{
	[SerializeField] private Camera _camera;
	[SerializeField] private Drawing _drawing;

	private Coroutine _drawCoroutine;

	private InputAction drawAction => InputSingletone.Instance.Drawing.Draw;
	private Vector2 mousePosition => _camera.ScreenToWorldPoint(InputSingletone.Instance.Drawing.MousePosition.ReadValue<Vector2>());

	protected void Awake()
	{
		InputSingletone.Instance.Enable();
	}

	protected void OnEnable()
	{
		drawAction.started += OnDraw;
		drawAction.canceled += OnStopDraw;
	}

	protected void OnDisable()
	{
		drawAction.started -= OnDraw;
		drawAction.canceled -= OnStopDraw;
	}

	private void OnDraw(InputAction.CallbackContext context)
	{
		_drawing.StartDraw(mousePosition);
		_drawCoroutine = StartCoroutine(DrawCoroutine());
	}

	private void OnStopDraw(InputAction.CallbackContext context)
	{
		_drawing.StopDraw(mousePosition);
		if (_drawCoroutine != null)
		{
			StopCoroutine(_drawCoroutine);
		}
	}

	private IEnumerator DrawCoroutine()
	{
		while (_drawing.IsDrawing)
		{
			_drawing.Draw(mousePosition);
			yield return null;
		}
	}
}
