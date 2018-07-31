using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

	[SerializeField] Text textComponent;
	System.String globalInput;
	System.String auxGlobalInput = "0";
	System.String operand = "INVALID";
	int frame = 0;

	public void Start()
	{
		globalInput = "0";
	}

	public void Update()
	{
		if((Input.anyKeyDown) && (Input.inputString != ""))
		{
			if((Input.GetKeyDown(KeyCode.Delete)) || (Input.GetKeyDown(KeyCode.Escape)))
			{
				globalInput = "0";
			}
			else if(Input.GetKeyDown(KeyCode.Backspace))
			{
				globalInput = globalInput.Remove(globalInput.Length-1, 1);
				if(globalInput == "")
				{
					globalInput = "0";
				}
			}
			else if((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
			{
				int num1 = 0;
				int num2 = 0;
				int result = 0;
				int.TryParse(auxGlobalInput, out num1);
				int.TryParse(globalInput, out num2);
				if(operand == "+"){result = num1 + num2;}
				else if(operand == "-"){result = num1 - num2;}
				else if(operand == "*"){result = num1 * num2;}
				else if(operand == "/"){result = num1 / num2;}

				if(!(operand == "INVALID"))
				{
					operand = "INVALID";
					globalInput = result.ToString();
					auxGlobalInput = globalInput;
				}
			}
			else if((Input.GetKeyDown(KeyCode.Plus)) || (Input.GetKeyDown(KeyCode.Minus)) ||
					(Input.GetKeyDown(KeyCode.Asterisk)) || (Input.GetKeyDown(KeyCode.Slash)) )
			{
				int num1 = 0;
				int num2 = 0;
				int result = 0;
				int.TryParse(auxGlobalInput, out num1);
				int.TryParse(globalInput, out num2);
				if(operand == "+"){result = num1 + num2;}
				else if(operand == "-"){result = num1 - num2;}
				else if(operand == "*"){result = num1 * num2;}
				else if(operand == "/"){result = num1 / num2;}

				if(operand != "INVALID")
				{
					globalInput = result.ToString();
				}
				auxGlobalInput = globalInput;
				operand = Input.inputString;
				// arreglar
			}
			else
			{
				System.String tempInput = Input.inputString;
				if(globalInput == "0" || globalInput == "RESULT")
				{
					globalInput = "";
				}
				globalInput += tempInput;
			}

			textComponent.text = globalInput;
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			Debug.Log("Hola Santi estamos en el frame: " + frame);
		}
		frame++;
	}

	public void Button(Button boton)
	{
		Debug.Log("Hola Santi estamos en el frame: " + boton.name);
	}

}
