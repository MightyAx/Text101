using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text;
	private enum States { mission, call, call_wait, travel, find_liara, mission_liara, call_liara, travel_liara, success }
	private States gameState;

	// Use this for initialization
	void Start ()
	{
		gameState = States.mission;
	}

	// Update is called once per frame
	void Update ()
	{
		print (gameState);
		if (gameState == States.mission) {
			state_mission ();
		} else if (gameState == States.call) {
			state_call ();
		} else if (gameState == States.call_wait) {
			state_call_wait ();
		} else if (gameState == States.travel) {
			state_travel ();
		}
	}

	void state_mission ()
	{
		text.text = "You are Commander Shepard, tasked with bringing down Sarren with the Normandy and her crew.\n" +
					"Sarren's only known associate is Matriach Benezia. \n\n" +
					"You can [C]all Benezia, [T]ravel to Benezia, or try to find her daghter [L]iara.";
		if (Input.GetKeyDown (KeyCode.C)) {
			gameState = States.call;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			gameState = States.travel;
		}
	}

	void state_call ()
	{
		text.text = "You call Benezia over the Cortex, you are greeted by an assistant that puts you on hold.\n\n" +
					//"You hear an advert that describes Benezia's favorite store on the Citadel.\n\n" +;
					"You can [W]ait, or you can [H]ang up.";
		if (Input.GetKeyDown (KeyCode.W)) {
			gameState = States.call_wait;
		} else if (Input.GetKeyDown (KeyCode.H)) {
			gameState = States.mission;
		}
	}

	void state_call_wait ()
	{
		text.text = "You hear an advert that describes Benezia's favorite store on the Citadel.\n\n" +
					"You can [W]ait, or you can [H]ang up.";
		if (Input.GetKeyDown (KeyCode.W)) {
			gameState = States.call_wait;
		} else if (Input.GetKeyDown (KeyCode.H)) {
			gameState = States.mission;
		}
	}
	
	void state_travel ()
	{
		text.text = "You travel accross the galaxy to Peek 15 of Noveria to confront Benzia.\n" +
					"You are Assualted by Biotic Commandos when you attempt to speak to Benezia. \n\n" +
					"They are too strong for you. You must [R]un Away!";
		if (Input.GetKeyDown (KeyCode.R)) {
			gameState = States.mission;
		}
	}
}
