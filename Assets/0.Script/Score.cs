using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private Text score_text;   //���� ���ھ�
    [SerializeField] private Text max_score_text;//�ְ� ���ھ�

    [SerializeField] private Text question_Text;    //���� ���
    [SerializeField] private List<string> questions; // ���� ����Ʈ

    [HideInInspector] public float nomal_score = 0; //���� ���ھ�
    [HideInInspector] public float question_score = 0;  //���� ��� ���ھ�
    private float max_score = 0;    //�ְ� ���ھ�

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
            nomal_score += Time.deltaTime * 13;   //nomal_score �� ����(13)
            question_score += Time.deltaTime * 13;
            score_text.text = Mathf.FloorToInt(nomal_score).ToString("0000");   //Mathf.FloorToInt : ������ ǥ��
        }
    }

    public void Die()
    {
        if (nomal_score > max_score)
        {
            max_score = nomal_score;//max_score �� ����
            max_score_text.text = Mathf.FloorToInt(max_score).ToString("0000");
        }
        nomal_score = 0;    //���� �ʱ�ȭ
        question_score = 0;
    }

    public void Question() //���� ���
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        randomIndex = Random.Range(0, questions.Count); //14���� ����
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
