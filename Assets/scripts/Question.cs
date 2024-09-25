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
        foreach (var t in listButton)
        {
            t.SetActive(false);
        }
        if (_correct != index)
        {
            StartGameControllers.Instance.SetLose(true);
            MainEndGame.Instance.SetDiem(StartGameControllers.Instance.GetPoint().ToString());
            gameObject.SetActive(false);
        }
        else
        {
            StartGameControllers.Instance.SetPoint();
            StartCoroutine(Win(listQuestion[index].text));
        }
    }

    private IEnumerator Win(string k)
    {
        textQuestion.text = "";
        string c = "Xin chúc mừng bạn đã trả lời đúng. Hãy tiếp tục với câu hỏi tiếp theo nhé.";
        foreach (var q in c)
        {
            textQuestion.text += q;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        if (_listQuestion.Count <= 0)
        {
            MainEndGame.Instance.SetDiem(StartGameControllers.Instance.GetPoint().ToString());
        }
    }

    [SerializeField] private TextMeshProUGUI textQuestion;

    private List<QuestionDenfine> _listQuestion = new List<QuestionDenfine>();
    public void CreateCauHoi()
    {
        _listQuestion.Clear();
        for (int i = 0; i < 7; i++)
        {
            _listQuestion.Add(new QuestionDenfine()
            {
                quest = "Câu hỏi "+i+", Câu hỏi 1, Câu hỏi 1",
                A = "A",
                B = "B",
                C = "C",
                D = "D",
                indexTrue = 1,
                type = 0
            });
        }
    }
    public void VaChamNPC(GameObject k = null)
    {
        if (StartGameControllers.Instance.GetLose()) return;
        if (_listQuestion.Count <= 0)
        {
            return;
        }
        InsertQuestion(_listQuestion[0]);
        _listQuestion.RemoveAt(0);
        gameObject.SetActive(true);

        if (k != null)
        {
            k.SetActive(false);
        }
    }

    private string _stringCount = "";
    private float _timeCount = 0;

    private IEnumerator RunText()
    {
        while (_stringCount.Length >= 1 && _stringCount.Length != textQuestion.text.Length)
        {
            textQuestion.text += _stringCount[textQuestion.text.Length];
            yield return new WaitForSeconds(0.05f);
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
        StartCoroutine(RunText());
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