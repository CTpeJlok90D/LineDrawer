using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
	[SerializeField] private WayDrawing _ownWay;
	[SerializeField] private float _moveTime = 1;
	[SerializeField] private UnityEvent _accident;
	[SerializeField] private UnityEvent _wayFinished;

	private Coroutine _moveCorotune;
	private bool _wayIsFinished = false;

	public WayDrawing OwnWay => _ownWay;
	public UnityEvent Accident => _accident;
	public UnityEvent WayFinished => _wayFinished;
	public bool WayIsFinished => _wayIsFinished;
	public bool IsMooving => _moveCorotune != null;

	public void StartMove()
	{
		if (_ownWay.CurrentWay == null)
		{
			throw new System.Exception($"Way was not found. Create way, before use {nameof(StartMove)} method");
		}

		_moveCorotune = StartCoroutine(MoveCoroutine());
	}

	public void StopMove()
	{
		if (_moveCorotune != null)
		{
			StopCoroutine(_moveCorotune);
		}
	}

	private IEnumerator MoveCoroutine()
	{
		for (float i = 0; i <= 1; i += Time.deltaTime / _moveTime)
		{
			transform.position = _ownWay.Evaluate(i);
			yield return null;
		}
		_wayIsFinished = true;
		_wayFinished.Invoke();
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out Character character) || other.TryGetComponent(out Wall wall))
		{
			StopMove();
			Accident.Invoke();
		}
	}
}
