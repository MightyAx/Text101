using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start ()
	{
		text.text = "Hello World";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			text.text = "You are Commander Shepard, tasked with bringing down Sarren with the Normandy and her crew.\n" +
						"Sarren's only known associate is Matriach Benezia. \n\n" +
						"You can [C]all Benezia, [T]ravel to Benezia, or try to find her daghter [L]iara.";
		}
	}
}
