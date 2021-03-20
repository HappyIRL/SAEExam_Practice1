using System.Collections;
using UnityEditor;
using UnityEngine;

public enum ItemType
{
	Grass,
	Stones,
	Rock,
	Goo,
	Basket,
	Pickaxe,
	Broom,
	Kettle,
	Plate,
	Spoon
}

public class InteractBase : MonoBehaviour, ItemInteraction
{
	[SerializeField] private ItemType itemType;

	public virtual void StartInteraction()
	{
		PickUp();
	}

	public virtual void StopInteraction()
	{

	}

	public ItemType GetItemType()
	{
		return itemType;
	}

	public Vector3 GetItemPosition()
	{
		return transform.position;
	}

	private void PickUp()
	{
		StartCoroutine(DestroyEndOfFrame());
	}

	private IEnumerator DestroyEndOfFrame()
	{
		yield return null;
		Destroy(this.gameObject);
	}
}
