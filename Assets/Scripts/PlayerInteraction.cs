using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField] private PlayerInput playerInput;
	[SerializeField] private PlayerRaycastInteraction raycastInteraction;

	private ItemInteraction currentRayInteraction;
	private ItemInteraction lastRayInteraction;

	private void OnEnable()
	{
		playerInput.TryInteract += OnTryInteract;
	}
	private void OnDisable()
	{
		playerInput.TryInteract -= OnTryInteract;
	}

	private void Update()
	{
		if (raycastInteraction.IsLookingAtCurrent)
		{
			//do stuff
		}
	}

	private void OnTryInteract()
	{
		Debug.Log("OnTryInteract");

		currentRayInteraction = raycastInteraction.CurrentInteraction;
		lastRayInteraction = raycastInteraction.LastInteraction;

		Debug.Log($"last:{lastRayInteraction} ; current:{currentRayInteraction}");

		if (currentRayInteraction != lastRayInteraction)
		{
			lastRayInteraction?.StopInteraction();

			currentRayInteraction?.StartInteraction();
		}
		else
		{
			currentRayInteraction?.StopInteraction();
		}
	}
}
