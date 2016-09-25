using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text;
	private enum States { mission, call, call_wait, travel, liara, mission_liara, call_liara, travel_liara, success }
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
		} else if (gameState == States.liara) {
			state_liara ();
		} else if (gameState == States.mission_liara) {
			state_mission_liara ();
		} else if (gameState == States.call_liara) {
			state_call_liara ();
		} else if (gameState == States.travel_liara) {
			state_travel_liara ();
		} else if (gameState == States.success) {
			state_success ();
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
		} else if (Input.GetKeyDown (KeyCode.L)) {
			gameState = States.liara;
		} 
	}
	
	void state_mission_liara ()
	{
		text.text = "You are Commander Shepard, tasked with bringing down Sarren with the Normandy and her crew.\n" +
					"You have enlisted the help of Liara to talk to her mother Matriach Benezia, Sarren's only known associate. \n\n" +
					"You can [C]all Benezia, [T]ravel to Benezia";
		if (Input.GetKeyDown (KeyCode.C)) {
			gameState = States.call_liara;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			gameState = States.travel_liara;
		}
	}
	
	void state_call ()
	{
		text.text = "You call Benezia over the Cortex, you are greeted by an assistant that puts you on hold.\n\n" +
					"You can [W]ait, or you can [H]ang up.";
		if (Input.GetKeyDown (KeyCode.W)) {
			gameState = States.call_wait;
		} else if (Input.GetKeyDown (KeyCode.H)) {
			gameState = States.mission;
		}
	}
	
	void state_call_liara ()
	{
		text.text = "Liara calls Benezia over the Cortex, she begins talking in an alien lanuage.\n" +
					"At first it seems to be going well, but Liara gets more and more angry until she eventually slams down the phone \n\n" +
					"You decide that this won't be possible over the phone and [G]ive up.";
		if (Input.GetKeyDown (KeyCode.G)) {
			gameState = States.mission_liara;
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

	void state_liara ()
	{
		text.text = "You travel accross the galaxy find Benezia's Daghter Liara, an archeologist and prothean expert.\n" +
					"She agrees to help talk to her mother who dosen't seem to be acting herself. \n\n" +
					"You can [R]esume your mission, together.";
		if (Input.GetKeyDown (KeyCode.R)) {
			gameState = States.mission_liara;
		}
	}
	
	void state_travel_liara ()
	{
		text.text = "You travel accross the galaxy to Peek 15 of Noveria to confront Benzia with her Daughter Liara\n" +
					"Together with Liara's Biotic powers you dispatch Benezia's Guards.\n" +
					"Liara projects a Biotic Barrier around her mother's mind, freeing her of her alligence to Sarren.\n\n" +
					"[Press any Key]";
		if (Input.anyKeyDown) {
			gameState = States.success;
		}
	}
	
	void state_success ()
	{
		text.text = "Free of Sarren's infulence Benezia devulges the intricicies of his plan.\n" +
					"Together with the Crew of the Normandy, Liara and her mother Benezia, you assault Sarren's base of operations.\n" +
					"You shoot Sarren in the head and the galaxy is saved.\n\n" +
					"[The End]";
	}
}
