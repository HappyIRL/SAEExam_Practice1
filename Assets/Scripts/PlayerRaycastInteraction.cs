using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerRaycastInteraction : MonoBehaviour
{
	[SerializeField] private Transform playerTarget;
	public ItemInteraction CurrentInteraction { get; private set; }
	public ItemInteraction LastInteraction { get; private set; }

	public bool IsLookingAtCurrent { get; private set; }

	private void Update()
	{
		if (Physics.Raycast(playerTarget.position, playerTarget.forward, out RaycastHit hitInfo, Mathf.Infinity))
		{
			Debug.Log(hitInfo.collider.transform.parent.gameObject.name);

			if (hitInfo.collider.transform.parent.TryGetComponent(out ItemInteraction itemInteraction))
			{
				Debug.Log("item has interaction");
				if (CurrentInteraction != null && itemInteraction != CurrentInteraction) LastInteraction = CurrentInteraction;

				IsLookingAtCurrent = true;

				CurrentInteraction = itemInteraction;
			}
			else
			{
				CurrentInteraction = null;
				IsLookingAtCurrent = false;
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(playerTarget.position, playerTarget.forward);
	}
}
