using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question : MonoBehaviour
{
    public static Question Instance;
    [SerializeField] private List<TextMeshProUGUI> listQuestion = new List<TextMeshProUGUI>();
    [SerializeField] private List<GameObject> listButton = new List<GameObject>();
    private int _correct = -1;
    public void ButtonChonDapAn(int index)
    {
        if (_correct != index)
        {
            MainEndGame.Instance.SetDiem(StartGameControllers.Instance.GetPoint().ToString());
            gameObject.SetActive(false);
        }
        else
        {
            StartGameControllers.Instance.SetPoint();
        }
    }

    [SerializeField] private TextMeshProUGUI textQuestion;

    private void Awake()
    {
        InsertQuestion(new QuestionDenfine()
        {
            quest = "Câu hỏi 1, Câu hỏi 1, Câu hỏi 1",
            A = "A",
            B = "B",
            C = "C",
            D = "D",
            indexTrue = 1,
            type = 0
        });
    }

    private string _stringCount = "";
    private float _timeCount = 0;
    private void Update()
    {
        _timeCount += Time.deltaTime;
        if (_timeCount >= 0.05f)
        {
            _timeCount = 0;
            if (_stringCount.Length >= 1 && _stringCount.Length != textQuestion.text.Length)
            {
                textQuestion.text += _stringCount[textQuestion.text.Length];
            }

        }
    }

    private IEnumerator ShowButton(QuestionDenfine t)
    {
        while (_stringCount.Length != textQuestion.text.Length)
        {
            yield return null;
        }
        float delay = 0.3f;
        if (t.A.Length >= 1)
        {
            listButton[0].SetActive(true);
            yield return new WaitForSeconds(delay);
        }
        if (t.B.Length >= 1)
        {
            listButton[1].SetActive(true);
            yield return new WaitForSeconds(delay);
        }
        if (t.C.Length >= 1)
        {
            listButton[2].SetActive(true);
            yield return new WaitForSeconds(delay);
        }
        if (t.D.Length >= 1)
        {
            listButton[3].SetActive(true);
            yield return new WaitForSeconds(delay);
        }

    }

    public void InsertQuestion(QuestionDenfine t)
    {
        textQuestion.text = "";
        _stringCount = t.quest;
        foreach (var q in listButton)
        {
            q.SetActive(false);
        }
        if (t.A.Length >= 1)
        {
            listQuestion[0].text = t.A;
        }

        if (t.B.Length >= 1)
        {
            listQuestion[1].text = t.B;
        }

        if (t.C.Length >= 1)
        {
            listQuestion[2].text = t.C;
        }

        if (t.D.Length >= 1)
        {
            listQuestion[3].text = t.D;
        }
        _correct = t.indexTrue;
        StartCoroutine(ShowButton(t));
    }
}


public class QuestionDenfine
{
    public string quest = "";
    public string A = "";
    public string B = "";
    public string C = "";
    public string D = "";
    public int indexTrue = 0;
    public sbyte type = 0;
}