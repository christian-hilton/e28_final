using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDataSource : MonoBehaviour
{
    Question[] questions;
    public int currentQuestion;

    public int questionCorrectValue = 100;
    public int questionIncorrectValue = -100;

    static QuestionDataSource instance;

    public GameManager gameManager;

    void Awake(){

        if (instance == null) {

            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this) {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);   
            
            // skip subsequent setup for an unnecessary instance
            return;
        }

        DontDestroyOnLoad(gameObject);

        currentQuestion = 0;
        setupQuestionData();

        // GameManager.getInstance().questionDataSource = this;
    }

    public static QuestionDataSource getInstance(){
        // if (instance == null) {
        //     instance = new QuestionDataSource();
        // }
        return instance;
    }

    Question getQuestion(int index)
    {
        // todo overflow
        return questions[index];
    }

    public Question getQuestion()
    {   
        Question question = getQuestion(currentQuestion);
        currentQuestion += 1;
        // todo overflow

        return question;
    }

    void setupQuestionData() 
    {
        Question q1 = new Question("What is a mandoline used for?", new string[] {"Searing", "Thin Slicing", "Meat tenderizing", "Rough Chopping"}, 1);
        Question q2 = new Question("Which of these is a winter fruit?", new string[] {"Rutabega", "Cabbage", "Persimmon", "Blackberry"}, 2);
        Question q3 = new Question("Which is the primary ingredient of Hummus?", new string[] {"Chickpea", "Beans", "Tahini", "Sesame seeds"}, 0);
        Question q4 = new Question("Which is known as the most expensive spice?", new string[] {"Garam Masala", "Z'atar", "Persimmon", "Saffron"}, 3);
        Question q5 = new Question("Which is a strong source of protein?", new string[] {"cheese", "avocado", "fish", "eggplant"}, 2);
        Question q6 = new Question("Which fruit is Georgia famous for?", new string[] {"Apple", "Peach", "Persimmon", "eggplant"}, 1);
        Question q7 = new Question("Which animal is prosciutto made from", new string[] {"Cow", "Sheep", "Pig", "SafChickenron"}, 2);
        Question q8 = new Question("Which is a key ingredient for Pesto?", new string[] {"Salad", "Argan Oil", "Butter", "Basil"}, 3);
        Question q9 = new Question("When is Tomato in season?", new string[] {"winter", "spring", "summer", "fall"}, 2);
        Question q10 = new Question("Which city is famous for it's style of pizza?", new string[] {"New Haven", "New York", "Naples", "All of the above"}, 3);
        Question q11 = new Question("Which of these is a winter fruit?", new string[] {"Rutabega", "Cabbage", "Persimmon", "Blackberry"}, 2);

        questions = new Question[] {q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11};
    }
}
