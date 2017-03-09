using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	//Los textos van en grupos de dos: beforePickUp y AfterPickUp.

	//Podemos hacer lo siguiente: al script PickUp se le pasa el TextManager,
	//del cual sustituirá DOS cadenas. Estas dos cadenas irán cambiando según una variable
	//local que cambiará cuando, despues de AfterPickUp, se llame a una función que lo cambie.
	//En preposition, añadiremos las preposiciones a destacar en cada uno.

	public string beforePickUp, afterPickUp;
	private int estadoActual;

	// Use this for initialization
	void Start () {
		estadoActual = 1;
		updateText ();		
	}

	void updateText()
	{
		if (estadoActual == 1) 
		{			
			beforePickUp = "Clean the area" +"<color=#ff0000ff> around </color>" + " the fireplace";
			afterPickUp = "Dig a fire pit and build a ring of rocks";
		}
		if (estadoActual == 2) 
		{
			beforePickUp = "The firewood is hidden" +"<color=#ff0000ff> under </color>" + " a big rock next to a" + 
				"coconut tree" + "<color=#ff0000ff> in </color>"+ "the forest";
			afterPickUp = "Pile the firewood" + "<color=#ff0000ff> in </color>" + "the fire pit";
		}
		if (estadoActual == 3) 
		{
			beforePickUp = "The moss is hidden" + "<color=#ff0000ff> in </color>" + "a coconut tree hole" + 
				"<color=#ff0000ff> on </color>" + "the south side of the forest.";
			afterPickUp = "Place the moss" + "<color=#ff0000ff> on </color>" + "the pile of firewood";
		}
		if (estadoActual == 4) 
		{
			beforePickUp = "The firewood sticks are hidden" + "<color=#ff0000ff> behind </color>" + 
				"bushes" + "<color=#ff0000ff> on </color>" + "the west side of the forest";
			afterPickUp = "Take the firewood sticks to the fireplace";
		}
		if (estadoActual == 5) 
		{
			beforePickUp = "The bunch of dry leaves is hidden" +  "<color=#ff0000ff> inside </color>" + 
				"the core of an old stump" +  "<color=#ff0000ff> in </color>" + 
				"the forest";
			afterPickUp = "Take the dry leaves to the fireplace";
		}
		if (estadoActual == 6)
		{
			beforePickUp = "Arrange the firewood sticks in the fireplace";
			afterPickUp = "Find the spyglass lying" + "<color=#ff0000ff> on </color>" + "the beach";
		}
		if (estadoActual == 7) 
		{
			beforePickUp = "Light up the fire with the spyglass";
			afterPickUp = "First level complete.";
		}
	}

	public void SiguienteAccion()
	{	estadoActual++;	}

	// Update is called once per frame
	void Update () {
		
	}
}
