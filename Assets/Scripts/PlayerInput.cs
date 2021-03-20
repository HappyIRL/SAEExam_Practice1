using System;
using UnityEditor;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public event Action TryInteract;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1))
		{
			TryInteract?.Invoke();
		}
	}
}
