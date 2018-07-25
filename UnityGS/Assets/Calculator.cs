using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour {

	int frame = 0;
	// Use this for initialization
	void Start () {
		Debug.Log("Hello Word");
	}

	int input;
	void Update ()
	{
		if (Input.anyKeyDown)
		{
			System.String tempInput = Input.inputString;
			int.TryParse(tempInput, out input);
			Debug.Log("Apretaste la letra: " + tempInput);
		}

		else if (Input.GetKeyDown(KeyCode.F))
		{
			Debug.Log("Hola Santi estamos en el frame: " + frame);
		}
		frame++;
	}
	// Update is called once per frame
}
