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
		if 		(gameState == States.mission) 		{ mission (); }
		else if (gameState == States.call) 			{ call (); }
		else if (gameState == States.call_wait)	 	{ call_wait (); }
		else if (gameState == States.travel) 		{ travel (); }
		else if (gameState == States.liara) 		{ liara (); }
		else if (gameState == States.mission_liara)	{ mission_liara (); }
		else if (gameState == States.call_liara)	{ call_liara (); }
		else if (gameState == States.travel_liara)	{ travel_liara (); }
		else if (gameState == States.success)		{ success (); }
	}

	void mission ()
	{
		text.text = "You are Commander Shepard, SPECTRE and captain of the spaceship Normandy.\n" +
					"You have been ordered to stop fellow SPECTRE Sarren from destroying the galaxy.\n" +
					"Sarren's only known associate is Matriach Benezia. \n\n" +
					"You can:\n[C]all Benezia,\n[T]ravel to Benezia,\n[F]ind her daughter Liara.";
		if (Input.GetKeyDown (KeyCode.C)) {
			gameState = States.call;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			gameState = States.travel;
		} else if (Input.GetKeyDown (KeyCode.F)) {
			gameState = States.liara;
		} 
	}
	
	void mission_liara ()
	{
		text.text = "You have been ordered to stop fellow SPECTRE Sarren from destroying the galaxy.\n" +
					"You have enlisted the help of Liara to talk to her mother Matriach Benezia, Sarren's only known associate. \n\n" +
					"You can:\n[C]all Benezia,\n[T]ravel to Benezia";
		if (Input.GetKeyDown (KeyCode.C)) {
			gameState = States.call_liara;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			gameState = States.travel_liara;
		}
	}
	
	void call ()
	{
		text.text = "You call Benezia over the Cortex.\nYou are greeted by an assistant that puts you on hold.\n\n" +
					"You can:\n[W]ait, or you can [H]ang up.";
		if (Input.GetKeyDown (KeyCode.W)) {
			gameState = States.call_wait;
		} else if (Input.GetKeyDown (KeyCode.H)) {
			gameState = States.mission;
		}
	}
	
	void call_liara ()
	{
		text.text = "Liara calls Benezia over the Cortex.\nShe begins talking in an alien lanuage.\n" +
					"At first it seems to be going well...\nLiara gets more and more angry until she slams down the phone.\n\n" +
					"[G]ive up, this won't be possible over the phone.";
		if (Input.GetKeyDown (KeyCode.G)) {
			gameState = States.mission_liara;
		}
	}

	void call_wait ()
	{
		text.text = "You hear an advert for Benezia's favorite store on the Citadel.\n\n" +
					"You can:\n[W]ait, or you can [H]ang up.";
		if (Input.GetKeyDown (KeyCode.W)) {
			gameState = States.call_wait;
		} else if (Input.GetKeyDown (KeyCode.H)) {
			gameState = States.mission;
		}
	}
	
	void travel ()
	{
		text.text = "You travel accross the galaxy to Noveria to confront Benzia.\n" +
					"You are Assualted by her Biotic Commandos. \n\n" +
					"They are too strong for you. You must [R]un Away!";
		if (Input.GetKeyDown (KeyCode.R)) {
			gameState = States.mission;
		}
	}

	void liara ()
	{
		text.text = "You travel accross the galaxy find Benezia's Daughter Liara.\n" +
					"Liara is an archeologist and prothean expert.\nShe agrees to help talk to her mother.\nShe is worried that Benezia doesn't seem to be acting herself.\n\n" +
					"[R]esume your mission, together.";
		if (Input.GetKeyDown (KeyCode.R)) {
			gameState = States.mission_liara;
		}
	}
	
	void travel_liara ()
	{
		text.text = "You travel accross the galaxy to Noveria.\n" +
					"Together with Liara's Biotic powers you the Commandos.\n" +
					"Liara projects a Biotic Barrier around her mother's mind.\nThis frees Benezia of her alligence to Sarren.\n\n" +
					"[Press any Key]";
		if (Input.anyKeyDown) {
			gameState = States.success;
		}
	}
	
	void success ()
	{
		text.text = "Benezia devulges the intricicies of Sarren's plan.\n" +
					"With the Crew of the Normandy, Liara and her mother Benezia:\n\nYou assault Sarren's base of operations.\n" +
					"You shoot Sarren in the head.\nTthe galaxy is saved.\n\n" +
					"[The End]";
	}
}
