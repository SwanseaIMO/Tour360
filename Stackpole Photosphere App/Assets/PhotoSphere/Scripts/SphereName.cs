using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SphereName : MonoBehaviour {

    public TextMesh TextOutput;
	// Use this for initialization
	void Start () {
        TextOutput.text =   this.transform.parent.gameObject.transform.name;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
