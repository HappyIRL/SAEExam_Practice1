using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	[SerializeField] private PlayerInteraction playerInteraction;

	private List<ItemType> collectedItems = new List<ItemType>();

	public event Action InventoryChanged;

	private void OnEnable()
	{
		playerInteraction.StartInteraction += OnTryPickUp;
	}

	private void OnDisable()
	{
		playerInteraction.StartInteraction -= OnTryPickUp;
	}
	private void OnTryPickUp(ItemInteraction item)
	{
		collectedItems.Add(item.GetItemType());
		InventoryChanged?.Invoke();
	}
}
