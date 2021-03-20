using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemInteraction
{
	public void StartInteraction();
	public void StopInteraction();
	public ItemType GetItemType();
	public Vector3 GetItemPosition();
}
