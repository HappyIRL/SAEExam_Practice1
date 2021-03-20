using UnityEngine;

public class InteractBase : MonoBehaviour, ItemInteraction
{
	public virtual void StartInteraction()
	{
		Debug.Log("Start");
		PickUp();
	}

	public virtual void StopInteraction()
	{
		Debug.Log("Stop");

	}

	private void PickUp()
	{
		Destroy(this.gameObject);
	}
}
