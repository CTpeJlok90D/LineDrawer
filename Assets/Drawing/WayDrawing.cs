using System;
using UnityEngine;
using UnityEngine.Events;

public class WayDrawing : Drawing
{
	[SerializeField] private UnityEvent<Line> _wayUpdated;
	private Line _currentWay;

	public Line CurrentWay => _currentWay;
	public UnityEvent<Line> WayUpdated => _wayUpdated;

	public float Disatance
	{
		get
		{
			if (_currentWay == null)
			{
				return 0;
			}
			return _currentWay.Resolution * (_currentWay.LineRenderer.positionCount - 1);
		}
	}

	public Vector2 Evaluate(float value)
	{
		if (value < 0 || value > 1)
		{
			throw new ArgumentException("value must be between 0 and 1!");
		}
		if (_currentWay == null)
		{
			throw new Exception($"you can't use {nameof(Evaluate)} function, before create way!");
		}

		float evaluateWayDistance = Disatance * value;
		int pointNumber = (int)(evaluateWayDistance / CurrentWay.Resolution);
		Vector2 positionOne = _currentWay.LineRenderer.GetPosition(pointNumber);
		Vector2 positionTwo = _currentWay.LineRenderer.GetPosition(pointNumber + 1);
		float procentBetweenPositions = (evaluateWayDistance - pointNumber * _currentWay.Resolution) / _currentWay.Resolution;
		Vector2 result = Vector2.Lerp(positionOne, positionTwo, procentBetweenPositions);
		return result;
	}

	protected void OnEnable()
	{
		DrawStopped.AddListener(OnStopDraw);
	}

	protected void OnDisable()
	{
		DrawStopped.RemoveListener(OnStopDraw);
	}

	private void OnStopDraw(Line line)
	{
		if (line == null)
		{
			return;
		}
		if (_currentWay != null)
		{
			_currentWay.DestroySelf();
		}
		_currentWay = line;
		_wayUpdated.Invoke(_currentWay);
	}
}
