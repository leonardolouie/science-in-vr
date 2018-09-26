using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class textcontrol : MonoBehaviour {




	public Questions[] question;
	public Questions[] skeletal;





	int answer =0;
    public int numberofloop;
    int loopcount=0;

    int correctanswer;
    int wronganswer;
	int randomquestionIndex;

	private static List<Questions> unansweredQuestion;
	private Questions currentQuestion;
	private static List<string> firstChoice;
	private static List<string> secondChoice;
	private static List<string> thirdChoice;
	private static List<string> fourthChoice;
	private static List<string> correctAnswer;
	public Text txtquestion;
    public Text over;
    public Text prompt;
    public Text questionnumber;
	public Text txtfirst;
	public Text txtsecond;
	public Text txtthird;
	public Text txtfourth;
    public Text txtcorrectanswer;
    public Text txtwronganswer;
    public Text txtAverage;


    public GameObject resultpanel;
	public GameObject Quizpanel,correctImage,wrongImage;











    void Awake() 
	{


		if (unansweredQuestion == null || unansweredQuestion.Count == 0) 
		{    
			//Dito pinapasa yung question
			unansweredQuestion = question.ToList<Questions>();
		}



		GetRandomQuestion ();
	
	    
	}
	
	// Update is called once per frame
	void GetRandomQuestion()

	{

        over.text = numberofloop.ToString();
        if (loopcount != numberofloop)
        {
            Debug.Log("question #"+loopcount);
            Debug.Log(unansweredQuestion.Count);
            if (unansweredQuestion.Count > 0)
            {
                randomquestionIndex = Random.Range(0, unansweredQuestion.Count);

                currentQuestion = unansweredQuestion[randomquestionIndex];
                txtquestion.text = currentQuestion.tanong;
                txtfirst.text = currentQuestion.firstchoice;
                txtsecond.text = currentQuestion.secondchoice;
                txtthird.text = currentQuestion.thirdchoice;
                txtfourth.text = currentQuestion.fourthchoice;
                unansweredQuestion.RemoveAt(randomquestionIndex);
                loopcount++;
                questionnumber.text = loopcount.ToString();
            }
            else
            {
                Debug.Log("Quiz Finish");
                //Logic If Quiz is stop randoming
            }
        }
        else
        {

            Debug.Log("Quiz Finish"+"Correct Answer is"+correctanswer+"and wrong answer is"+wronganswer);
            resultpanel.SetActive(true);
            Quizpanel.SetActive(false);
            txtcorrectanswer.text = correctanswer.ToString();
            txtwronganswer.text = wronganswer.ToString();
			float a = (float)correctanswer;
			txtAverage.text = ((a / 15) * 100).ToString("0") + "%";
            PlayerPrefs.SetInt("SolarScore", correctanswer);
		

        }
	

	}



	public bool isCorrect()

	{

        if (answer == System.Convert.ToInt32(currentQuestion.correctanswer))
        {
            //Dito yung animation kapag tama
			correctImage.SetActive(true);
			wrongImage.SetActive (false);
			correctImage.GetComponent<Animator> ().SetTrigger ("correct");

            correctanswer++;
            return true;
        }
        else
        {
            //Dito yung animation kapag maliii
			wrongImage.SetActive(true);
			correctImage.SetActive (false);
			wrongImage.GetComponent<Animator> ().SetTrigger ("correct");
            wronganswer++;
            Handheld.Vibrate();
            return false;
        }
	}

	public void answer1 ()
	{
		answer = 1;

		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
		GetRandomQuestion ();

	


	}

	public void answer2()
	{

		answer = 2;
		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
	
		GetRandomQuestion ();

	}
	public void answer3()
	{

		answer = 3;
		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");

		GetRandomQuestion ();

	}


	public void answer4()
	{
		answer = 4;
		if (isCorrect () == true)
			Debug.Log ("Answer is Correct");
		else
			Debug.Log ("Answer is Wrong");
	
		GetRandomQuestion ();

	}








   
    

}
