using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private Text score_text;   //현재 스코어
    [SerializeField] private Text max_score_text;//최고 스코어

    [SerializeField] private Text question_Text;    //문제 출력
    [SerializeField] private List<string> questions; // 문제 리스트

    [HideInInspector] public float nomal_score = 0; //현재 스코어
    [HideInInspector] public float question_score = 0;  //점수 계산 스코어
    private float max_score = 0;    //최고 스코어

    [SerializeField] private GameObject startText;

    int randomIndex;
    bool isStart = true;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStart)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            isStart = false;
            startText.SetActive(false);
        }

        if (Time.timeScale != 0 && !isStart)
        {
            nomal_score += Time.deltaTime * 13;   //nomal_score 값 증가(13)
            question_score += Time.deltaTime * 13;
            score_text.text = Mathf.FloorToInt(nomal_score).ToString("0000");   //Mathf.FloorToInt : 정수로 표시
        }
    }

    public void Die()
    {
        if (nomal_score > max_score)
        {
            max_score = nomal_score;//max_score 값 갱신
            max_score_text.text = Mathf.FloorToInt(max_score).ToString("0000");
        }
        nomal_score = 0;    //점수 초기화
        question_score = 0;
    }

    public void Question() //문제 출력
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        randomIndex = Random.Range(0, questions.Count); //14까지 정답
        string randomQuestion = questions[randomIndex];
        question_Text.text = randomQuestion;
        question_score = 0;
    }

    public void O_Button()
    {
        if (randomIndex <= 14)
            panel.SetActive(false);
        else
        {
            nomal_score -= 30;
            panel.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void X_Button()
    {
        if (randomIndex < 14)
        {
            nomal_score -= 30;
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
