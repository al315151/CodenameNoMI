using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTarget : MonoBehaviour {

    // Use this for initialization
    public void SetCurrentTarget(string target)
    {
        GetComponent<Text>().text = target;
    }
}
