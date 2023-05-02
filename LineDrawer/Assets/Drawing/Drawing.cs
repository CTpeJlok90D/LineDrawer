using UnityEngine;
using UnityEngine.Events;

public class Drawing : MonoBehaviour
{
	[Header("Drawing")]
    [SerializeField] private Line _linePrefab;
	[Header("Start position")]
	[SerializeField] private Transform _startDrawCenter;
	[SerializeField] private float _startDrawRadius = 0.25f;
	[Header("EndPosition's")]
	[SerializeField] private Transform[] _endDrawCenters;
	[SerializeField] private float _endDrawRadius = 0.25f;
	[Header("Events")]
	[SerializeField] private UnityEvent<Vector2> _drawStarted;
	[SerializeField] private UnityEvent<Line> _drawStopped;

	private Line _drawingLine;

	public bool AllowDraw = true;
	public Line DrawingLine => _drawingLine;
	public bool IsDrawing => _drawingLine != null;
	public UnityEvent<Vector2> DrawStarted => _drawStarted;
	public UnityEvent<Line> DrawStopped => _drawStopped;

	public void StartDraw(Vector2 drawPosition)
	{
		if (CanStartDrawHere(drawPosition) == false || AllowDraw == false)
		{
			return;
		}
		_drawStarted.Invoke(drawPosition);
		_drawingLine = Instantiate(_linePrefab);
		Draw(drawPosition);
	}

	public void Draw(Vector2 drawPosition)
	{
		_drawingLine.ContinueDraw(drawPosition);
	}

	public void StopDraw(Vector2 stopDrawPosition)
	{
		if (CanStopDrawHere(stopDrawPosition) == false && _drawingLine != null)
		{
			_drawingLine.DestroySelf();
			_drawingLine = null;
		}
		_drawStopped.Invoke(_drawingLine);
		_drawingLine = null;
	}

	public bool CanStartDrawHere(Vector2 drawPosition)
	{
		return Vector2.Distance(_startDrawCenter.position, drawPosition) < _startDrawRadius;
	}

	public bool CanStopDrawHere(Vector2 endPosition)
	{
		foreach (Transform transform in _endDrawCenters)
		{
			if (Vector2.Distance(transform.position, endPosition) < _endDrawRadius)
			{
				return true;
			}
		}
		return false;
	}

#if UNITY_EDITOR
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(_startDrawCenter.position, _startDrawRadius);

		Gizmos.color = Color.red;
		foreach (Transform transform in _endDrawCenters)
		{
			Gizmos.DrawWireSphere(transform.position, _endDrawRadius);
		}
	}
#endif
}