using UnityEngine;

public class TipButton : MonoBehaviour
{
	[SerializeField] private GameObject _tip;

	public void OnTipClick()
	{
		_tip.SetActive(!_tip.activeSelf);
	}
}
