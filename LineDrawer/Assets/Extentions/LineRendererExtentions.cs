using UnityEngine;

public static class LineRendererExtentions
{
	public static Vector3 GetLastPosition(this LineRenderer _lineRenderer)
	{
		return _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
	}

	public static void SetLastPosition(this LineRenderer _lineRenderer, Vector3 position)
	{
		_lineRenderer.SetPosition(_lineRenderer.positionCount - 1, position);
	}
}
