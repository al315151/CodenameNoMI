using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
	private string TargetBeforePickUp, TargetAfterPickUp, AchievedText;
    public GameObject Destination;
	private GameObject textoHUD;

	private TextManager textScript;

    GameObject onHand, originalParent;
    bool goalAchieved, pickedUp;

    void Start()
    {
		textScript = GameObject.Find ("Patata").GetComponent<TextManager>();
        onHand = GameObject.Find("OnHand");



		textoHUD =  GameObject.Find("CurrentTargetText");
		textoHUD.GetComponent<Text> ().supportRichText = true;
		textoHUD.GetComponent<CurrentTarget>().SetCurrentTarget(TargetBeforePickUp);
		updateText ();

    }

    void OnMouseDown()
    {
        if (!goalAchieved)
        {
            pickedUp = true;
			//textoHUD.GetComponent<CurrentTarget>().SetCurrentTarget(TargetAfterPickUp);
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
			//textoHUD.GetComponent<CurrentTarget>().SetCurrentTarget(TargetBeforePickUp);
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
			//textoHUD.GetComponent<CurrentTarget>().SetCurrentTarget(AchievedText);
        }



    }

	void updateText()
	{
		

		if (pickedUp) 
		{
			this.TargetBeforePickUp = textScript.beforePickUp;
			this.TargetAfterPickUp = textScript.afterPickUp;
			textoHUD.GetComponent<CurrentTarget> ().SetCurrentTarget (TargetAfterPickUp);
		}

		if (goalAchieved) 
		{
			textScript.SiguienteAccion ();
			this.TargetBeforePickUp = textScript.beforePickUp;
			this.TargetAfterPickUp = textScript.afterPickUp;
			textoHUD.GetComponent<CurrentTarget> ().SetCurrentTarget (TargetBeforePickUp);
		}

	}




	void Update()
	{
		updateText ();
	}


}
