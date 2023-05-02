using UnityEngine;

public class Line : MonoBehaviour
{
	[SerializeField] private LineRenderer _lineRenderer;
	[SerializeField] private float _resolution = 0.1f;

	public LineRenderer LineRenderer => _lineRenderer;
	public float Resolution => _resolution;

	public Vector3[] Points
	{
		get
		{
			Vector3[] result = new Vector3[_lineRenderer.positionCount - 1];
			_lineRenderer.GetPositions(result);
			return result;
		}
	}

	public void ContinueDraw(Vector2 newPoint)
	{
		if (CanAppend(newPoint) == false)
		{
			return;
		}

		_lineRenderer.positionCount++;
		_lineRenderer.SetLastPosition(newPoint);
	}

	public void DestroySelf()
	{
		Destroy(gameObject);
	}

	private bool CanAppend(Vector2 newPosition)
	{
		if (_lineRenderer.positionCount == 0)
		{
			return true;
		}

		return Vector2.Distance(_lineRenderer.GetLastPosition(), newPosition) > _resolution;
	}
}
