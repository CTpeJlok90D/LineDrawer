using System.Collections;
using UnityEngine;

public class MovingWall : Wall
{
	[SerializeField] private Transform[] _points;
	[SerializeField] private float _moveSpeed = 1;
	[SerializeField] private Level _level;
	[SerializeField] private float _minDistanceToTarget = 0.1f;

	private int _currentPointIndex = 0;

	public Transform CurrentPoint => _points[_currentPointIndex];

	private void OnEnable()
	{
		_level.MoveStarted.AddListener(OnMoveStart);
	}

	private void OnDisable()
	{
		_level.MoveStarted.RemoveListener(OnMoveStart);
	}

	private void OnMoveStart()
	{
		StartCoroutine(InfinityMove());
	}

	private IEnumerator InfinityMove()
	{
		while (true)
		{
			transform.position = Vector2.MoveTowards(transform.position, CurrentPoint.position, Time.deltaTime * _moveSpeed);
			if (Vector2.Distance(transform.position, CurrentPoint.position) < _minDistanceToTarget)
			{
				_currentPointIndex++;
				if (_currentPointIndex >= _points.Length)
				{
					_currentPointIndex = 0;
				}
			}
			yield return null;
		}
	}
}
