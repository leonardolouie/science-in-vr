using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textcontrol : MonoBehaviour {

	// Use this for initialization
	public Text txtquestion;
	public Text txtfirst;
	public Text txtsecond;
	public Text txtthird;
	public Text txtfourth;


	List<string> question = new List<string>{"Teacher in history","Programming is", "Third Largest Planet"};
	List<string> firstChoice= new List<string>{"Sir Arjay", "fun", "Earth"};
	List<string> secondChoice= new List<string>{"Jayson", "hindi masaya","Jupiter"};
	List<string> thirdChoice= new List<string>{"qeqweqeqeqe3", "qweqeqew6","Saturn"};
	List<string> fourthChoice= new List<string>{"qeqweqeqeqe4", "qweqeqew7","Jupiter"};
	List<string> correctAnswer = new List<string>{"1","1","1"};

	public int answer =0;
	int randomquestionIndex;

	List<string> unansweredQuestion;



     void Awake() 
	{


		if (unansweredQuestion == null || unansweredQuestion.Count == 0) 
		{

			unansweredQuestion = question;
		}



		GetRandomQuestion ();
	    
	}
	
	// Update is called once per frame
	void GetRandomQuestion()

	{


		Debug.Log (unansweredQuestion.Count);
		if (unansweredQuestion.Count > 0) {
			randomquestionIndex = Random.Range (0, unansweredQuestion.Count);
			txtquestion.text = unansweredQuestion [randomquestionIndex];
			txtfirst.text = firstChoice [randomquestionIndex];
			txtsecond.text = secondChoice [randomquestionIndex];
			txtthird.text = thirdChoice [randomquestionIndex];
			txtfourth.text = fourthChoice [randomquestionIndex];
		} 
		else 
		{
			Debug.Log ("Quiz Finish");	
			//Logic If Quiz is stop randoming
		}

	

	}
	void DestroyAnsweredQuestion()
	{


		unansweredQuestion.RemoveAt (randomquestionIndex);
		firstChoice.RemoveAt (randomquestionIndex);
		secondChoice.RemoveAt (randomquestionIndex);
		thirdChoice.RemoveAt (randomquestionIndex);
		fourthChoice.RemoveAt (randomquestionIndex);
	}


	public bool isCorrect()

	{

		if (answer == System.Convert.ToInt32 (correctAnswer [randomquestionIndex]))
			return true;
		else
			return false;
	}

	public void answer1 ()
	{
		answer = 1;

		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
		DestroyAnsweredQuestion ();
		GetRandomQuestion ();
		


	}

	public void answer2()
	{

		answer = 2;
		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
		DestroyAnsweredQuestion ();
		GetRandomQuestion ();

	}
	public void answer3()
	{

		answer = 3;
		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
		DestroyAnsweredQuestion ();
		GetRandomQuestion ();

	}


	public void answer4()
	{
		answer = 4;
		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
		DestroyAnsweredQuestion ();
		GetRandomQuestion ();

	}



}
