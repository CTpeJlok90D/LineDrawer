using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
	[SerializeField] private Character _character;
	[SerializeField] private Animator _animator;

	private void Update()
	{
		_animator.SetBool("IsMoving", _character.IsMooving);
	}
}
