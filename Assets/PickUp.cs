using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public string TargetBeforePickUp, TargetAfterPickUp, AchievedText;
    public GameObject Destination;

    GameObject onHand, originalParent;
    bool goalAchieved, pickedUp;

    void Start()
    {
        onHand = GameObject.Find("OnHand");
        GameObject.Find("CurrentTargetText").GetComponent<CurrentTarget>().SetCurrentTarget(TargetBeforePickUp);
    }

    void OnMouseDown()
    {
        if (!goalAchieved)
        {
            pickedUp = true;
            GameObject.Find("CurrentTargetText").GetComponent<CurrentTarget>().SetCurrentTarget(TargetAfterPickUp);
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
            GameObject.Find("CurrentTargetText").GetComponent<CurrentTarget>().SetCurrentTarget(TargetBeforePickUp);
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
            goalAchieved = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GameObject.Find("CurrentTargetText").GetComponent<CurrentTarget>().SetCurrentTarget(AchievedText);
        }
    }

}
