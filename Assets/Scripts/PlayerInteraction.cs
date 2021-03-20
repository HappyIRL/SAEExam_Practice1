using System;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public event Action<ItemInteraction> StartInteraction;

	[SerializeField] private PlayerInput playerInput;
	[SerializeField] private PlayerRaycastInteraction raycastInteraction;
	[SerializeField] private TMPro.TMP_Text displayItemText;

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
			SetDisplayText();
		}
		else
		{
			displayItemText.text = "";
		}
	}

	private void SetDisplayText()
	{
		displayItemText.text = raycastInteraction.CurrentInteraction.GetItemType() + " (E to PickUp)";
		Vector3 itemPosition = raycastInteraction.CurrentInteraction.GetItemPosition();
		displayItemText.transform.position = new Vector3(itemPosition.x, itemPosition.y + 2, itemPosition.z);
	}

	private void OnTryInteract()
	{
		if (raycastInteraction.CurrentInteraction != raycastInteraction.LastInteraction)
		{
			raycastInteraction.LastInteraction?.StopInteraction();

			StartInteraction?.Invoke(raycastInteraction.CurrentInteraction);

			raycastInteraction.CurrentInteraction?.StartInteraction();
		}
		else
		{
			raycastInteraction.CurrentInteraction?.StopInteraction();
		}
	}
}
