using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour {

    //GAME STATES
    public static string IDLE = "idle";
    public static string LAUNCHED = "hook is launched";
    public static string HOOKED = "hooked";
    public static string FLYING = "warrior is flying";
    public static string FREE_FLYING = "warrior is free flying";
    public static string RESET_GAME = "reset game";
    public static string PP_POWERUP = "petpet power up";
	public static string KITE_POWERUP = "kite power up";
	public static string END_LEVEL = "end level";
	public static string PAUSE = "pause game";
	public static string UNPAUSE = "unpause game";
		//--------------------------------------------------
	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(this);
        buildBkg();
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change scene"))
        {
            Debug.Log("scene2 loading");
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("THIS GAME ENGINE BOO YAA");
	}

    private void buildBkg ()
    {
        //RemovePrevBkg();
        /*QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }*/
    }
}
