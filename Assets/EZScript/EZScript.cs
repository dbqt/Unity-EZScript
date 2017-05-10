using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZScript : MonoBehaviour {

    public EZPart StartPart;
    public int StartPartEnum = 0;


    public EZPart UpdatePart;

    // Use this for initialization
    void Start ()
    {
        if (StartPart != null) StartPart.Execute();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (UpdatePart != null) UpdatePart.Execute();
    }
}

public enum EZType
{
    None,
    DebugLog,
    DebugWarning,
    DebugError
}
