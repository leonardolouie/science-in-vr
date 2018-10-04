using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Linq;
using UnityEngine.SceneManagement;


public class textcontrol : MonoBehaviour {


	//for sounds 









	public Questions[] question;
	public Questions[] digistive;
	public Questions[] muscular;
	public Questions[] skeletal;
	public Questions[] respiratory;
	public Questions[] circulatory;
	public Questions[] urinary;






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
    //public Text prompt;
    public Text questionnumber;
	public Text txtfirst;
	public Text txtsecond;
	public Text txtthird;
	public Text txtfourth;
    public Text txtcorrectanswer;
    public Text txtwronganswer;
    public Text txtAverage;
	public Text quizName;
	public Text quizkoto;


    public GameObject resultpanel;
	public GameObject Quizpanel,correctImage,wrongImage;



	public void retry(){

		SceneManager.LoadScene (3);

	}








    public void start() 
	{      
		


		if (unansweredQuestion == null || unansweredQuestion.Count == 0) 
		{    
			//Dito pinapasa yung question
			if (PlayerPrefs.GetInt ("quizNo") == 1) {
				unansweredQuestion = question.ToList<Questions> ();
				quizName.text= "SOLAR SYSTEM";
				quizkoto.text="SOLAR SYSTEM";
			}
			if (PlayerPrefs.GetInt ("quizNo") == 2) {
				unansweredQuestion = digistive.ToList<Questions> ();
				quizName.text= "DIGISTIVE SYSTEM";
				quizkoto.text="DIGISTIVE SYSTEM";
			}


			if (PlayerPrefs.GetInt ("quizNo") == 3) {
				unansweredQuestion = skeletal.ToList<Questions> ();
				quizName.text= "SKELETAL SYSTEM";
				quizkoto.text="SKELETAL SYSTEM";
			}
			if (PlayerPrefs.GetInt ("quizNo") == 4) {
				unansweredQuestion = muscular.ToList<Questions> ();
				quizName.text= "MUSCULAR SYSTEM";
			}
			if (PlayerPrefs.GetInt ("quizNo") == 5) {
				unansweredQuestion = muscular.ToList<Questions> ();
				quizName.text= "RESPIRATORY SYSTEM";
			}

		
		
		
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
		
			if (PlayerPrefs.GetInt ("quizNo") == 1) {
				PlayerPrefs.SetInt ("Score1", correctanswer);
				StartCoroutine(sendscore(PlayerPrefs.GetString("name"),correctanswer, 1));
			}
			if (PlayerPrefs.GetInt ("quizNo") == 2) {
				PlayerPrefs.SetInt ("Score2", correctanswer);
				StartCoroutine(sendscore(PlayerPrefs.GetString("name"),correctanswer, 2));
			}


			if (PlayerPrefs.GetInt ("quizNo") == 3) {
				PlayerPrefs.SetInt ("Score3", correctanswer);
						StartCoroutine(sendscore(PlayerPrefs.GetString("name"),correctanswer, 3));
			}
			if (PlayerPrefs.GetInt ("quizNo") == 4) {
				PlayerPrefs.SetInt ("Score4", correctanswer);
				StartCoroutine(sendscore(PlayerPrefs.GetString("name"),correctanswer, 3));
			}
				

			for (int x = 1; x <= 4; x++) {

				Debug.Log(PlayerPrefs.GetInt("Score"+x , 0));

			}
		


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
			SoundManager.Playsound ("correctAnswer");
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






	IEnumerator sendscore (string name, int score, int lesson_id)
	{

		string SetUrl = "https://scivre.herokuapp.com/api/webscivreapisave";

		if(Validation1.checkConnectionfail() == true)
		{
			Debug.Log ("Error: Internet Connection");
		

		} 
		else 
		{
			WWWForm form = new WWWForm ();
			form.AddField ("name", name);
			form.AddField ("score", score);
			form.AddField ("lesson_id", lesson_id);
			Debug.Log (lesson_id);
		   

			using (UnityWebRequest www = UnityWebRequest.Post (SetUrl, form)) 
			{
				www.chunkedTransfer = false;
				yield return www.SendWebRequest();

				if (www.error != null)
				{
					Debug.Log("Error webserver request error: "+ www.error);
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);
					Validation1.UserData userData= JsonUtility.FromJson<Validation1.UserData> (www.downloadHandler.text);

				

				}
			}
		}
	}







   
    

}
