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
	bool mostrarResultado = false;
	int frame = 0;

	public void Start()
	{
		globalInput = "0";
	}

	public void Update()
	{
		if((Input.anyKeyDown) && (Input.inputString != ""))
		{
			if(mostrarResultado)
			{
				auxGlobalInput = globalInput;
				globalInput = "0";
				mostrarResultado = false;
			}
			logicaCalculator(Input.inputString);
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			Debug.Log("Hola Santi estamos en el frame: " + frame);
		}
		frame++;
	}

	public void Button(Button boton)
	{
		logicaCalculator(boton.name);
	}

	public void logicaCalculator(System.String input)
	{
		if((Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Escape)) && input != ".")
		{
			globalInput = "0";
			auxGlobalInput = "0";
			mostrarResultado = false;
			operand = "INVALID";
		}
		else if(Input.GetKeyDown(KeyCode.Backspace))
		{
			globalInput = globalInput.Remove(globalInput.Length-1, 1);
			if(globalInput == "")
			{
				globalInput = "0";
			}
		}
		else if(input == "+" || input == "-" || input == "/" || input == "*" ||
				Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || input == "=")
		{
			float num1 = 0;
			float num2 = 0;
			float result = 0;
			float.TryParse(auxGlobalInput, out num1);
			float.TryParse(globalInput, out num2);
			if(operand == "+"){result = num1 + num2;}
			else if(operand == "-"){result = num1 - num2;}
			else if(operand == "*"){result = num1 * num2;}
			else if(operand == "/"){result = num1 / num2;}
			else
			{
				auxGlobalInput = globalInput;
				globalInput = "0";
			}

			if(operand != "INVALID")
			{
				globalInput = result.ToString();
				auxGlobalInput = "0";
				if(input == "+" || input == "-" || input == "/" || input == "*")
				{
					mostrarResultado = true;
				}
			}

			if(input == "+" || input == "-" || input == "/" || input == "*")
			{
				operand = input;
			}
			else
			{
				operand = "INVALID";
			}
		}
		else
		{
			if(input == "." || input == ".") {input = ",";}

			if(globalInput == "0")
			{
				if(input != ",") {globalInput = "";}
			}

			globalInput += input;
		}

		textComponent.text = globalInput;
	}

}
