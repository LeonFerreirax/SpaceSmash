using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinderStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (BlinderGenerator.primeiroOn == false && BlinderGenerator.segundoOn == true)
        {
            Destroy(this.gameObject);
        }
		
	}
}
