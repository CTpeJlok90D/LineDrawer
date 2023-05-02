using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	[SerializeField] private List<Character> _characters;
	[SerializeField] private UnityEvent _moveStarted;
	[SerializeField] private UnityEvent _failed;
	[SerializeField] private UnityEvent _won;

	private LevelState _currentState = LevelState.Launched;

	public UnityEvent MoveStarted => _moveStarted;
	public UnityEvent Failed => _failed;
	public UnityEvent Won => _won;

	private bool AllWaysReady
	{
		get
		{
			foreach (Character character in _characters)
			{
				if (character.OwnWay.CurrentWay == null)
				{
					return false;
				}
			}
			return true;
		}
	}

	private bool AllWaysFinished
	{
		get
		{
			foreach (Character character in _characters)
			{
				if (character.WayIsFinished == false)
				{
					return false;
				}
			}
			return true;
		}
	}

	private void OnEnable()
	{
		foreach (Character characted in _characters)
		{
			characted.OwnWay.WayUpdated.AddListener(OnWayUpdated);
			characted.Accident.AddListener(OnAccident);
			characted.WayFinished.AddListener(OnWayFinished);
		}
	}

	private void OnDisable()
	{
		foreach (Character characted in _characters)
		{
			characted.OwnWay.WayUpdated.RemoveListener(OnWayUpdated);
			characted.Accident.RemoveListener(OnAccident);
			characted.WayFinished.RemoveListener(OnWayFinished);
		}
	}

	private void OnWayUpdated(Line line)
	{
		if (AllWaysReady)
		{
			StartAllMove();
		}
	}

	public void StartAllMove()
	{
		foreach (Character character in _characters)
		{
			character.OwnWay.AllowDraw = false;
			character.StartMove();
		}
		_moveStarted.Invoke();
	}

	private void OnWayFinished()
	{
		if (AllWaysFinished)
		{
			Win();
		}
	}

	public void Win()
	{
		if (_currentState != LevelState.Launched)
		{
			return;
		}
		_currentState = LevelState.Won;
		_won.Invoke();
	}

	private void OnAccident()
	{
		Fail();
	}

	public void Fail()
	{
		if (_currentState != LevelState.Launched)
		{
			return;
		}
		_currentState = LevelState.Fail;
		_failed.Invoke();
	}

	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private enum LevelState
	{
		Launched,
		Won,
		Fail
	}
}
