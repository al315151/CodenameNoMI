using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
	public string TargetBeforePickUp, TargetAfterPickUp, AchievedText;
	public GameObject Destination;
	public GameObject onHand;

	//public CurrentTarget m_CurrentTarget;
	private GameObject originalParent;
	bool goalAchieved, pickedUp;

	void Start()
	{
		onHand = GameObject.Find ("OnHand");
		//m_CurrentTarget.SetCurrentTarget(TargetBeforePickUp);
	}

	void OnMouseDown()
	{
		if (!goalAchieved)
		{
			pickedUp = true;
			//m_CurrentTarget.SetCurrentTarget(TargetAfterPickUp);
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().isKinematic = true;
			if (this.transform.parent != null)
				originalParent = this.transform.parent.gameObject;
			this.transform.parent = onHand.transform;
			this.transform.position = onHand.transform.position;
		}
	}

	void OnMouseUp()
	{
		if (!goalAchieved)
		{
			pickedUp = false;
			GetComponent<Rigidbody>().isKinematic = false;
			//m_CurrentTarget.SetCurrentTarget(TargetBeforePickUp);
			if (originalParent == null)
				this.transform.parent = null;
			else
				this.transform.parent = originalParent.transform;
			GetComponent<Rigidbody>().useGravity = true;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject == Destination && !pickedUp)
		{
			this.transform.parent = col.transform;
			this.transform.position = col.transform.position;
			//this.transform.rotation = new Quaternion (0, 0, 0, 0);
			goalAchieved = true;
			GetComponent<Rigidbody>().isKinematic = true;
			//m_CurrentTarget.SetCurrentTarget(AchievedText);
		}
	}

}
