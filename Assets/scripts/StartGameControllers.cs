﻿using System;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
/*
 * @since04
 * @int04
 */

public class StartGameControllers : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObPlayer = new List<GameObject>();
    private int _index = 0;
    private List<GameObject> _listNPC = new List<GameObject>();
    [SerializeField] private GameObject transformNPC;

    [SerializeField] private List<PlayerControllers> playerControllers = new List<PlayerControllers>();
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private TMP_InputField inputName;
    private bool _isStart = false;
    [SerializeField] private GameObject noLogin;
    [SerializeField] private MainEndGame mainEndGame;

    [SerializeField] private Question question;
    private byte _point = 0;
    private bool _lose = false;

    [SerializeField] private GameObject joyMove;

    bool isPc()
    {
        return Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer;
    }

    public void SetLose(bool c)
    {
        _lose = c;
    }

    public bool GetLose()
    {
        return _lose;
    }

    public byte GetPoint()
    {
        return _point;
    }

    public void SetPoint(byte point = 1)
    {
        _point += point;
    }

    public string GetNamePlayer()
    {
        if (inputName.text.Length <= 0) return "SV PDU";
        return inputName.text;
    }

    public CinemachineVirtualCamera GetCinemachineVirtualCamera()
    {
        return cinemachineVirtualCamera;
    }

    public static StartGameControllers Instance;

    public void SetNoCamera()
    {
        cinemachineVirtualCamera.Follow = noLogin.transform;
    }

    public void SetHaveCameraFromIndex()
    {
        cinemachineVirtualCamera.Follow = playerControllers[_index].transform;
    }

    public void MenuChinh()
    {
        _isStart = false;
        SetNoCamera();
        gameObject.SetActive(true);
        foreach (var t in playerControllers)
        {
            t.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        DefineQuestion.Run();
        ResetNPC();
        MenuChinh();
        Sound().PlaySound("cow");
        if (isPc())
        {
            joyMove.SetActive(false);
        }
    }

    private float _xMin = -6;
    private float _yMin = -1.18f;
    private float _yMax = 14f;
    private float _xMax = 95f;
    private float Rand(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    private bool _moveRight = true;

    public void MoveUpdateForm()
    {
        if (_isStart) return;


        // Điểm đích cuối cùng
        Vector3 targetPosition = new Vector3(
            _moveRight ? _xMax : _xMin,
            noLogin.transform.position.y,
            0);
        // Sử dụng Lerp để di chuyển mượt mà hơn
        noLogin.transform.position = Vector3.Lerp(
            noLogin.transform.position,
            targetPosition,
            0.01f * Time.deltaTime); // Điều chỉnh tốc độ với deltaTime

        if (noLogin.transform.position.x >= _xMax)
        {
            _moveRight = false;
        }
        else if (noLogin.transform.position.x <= _xMin)
        {
            _moveRight = true;
        }
    }
    private void Update()
    {
        MoveUpdateForm();
    }

    private void Awake()
    {
        foreach (Transform t in transformNPC.transform)
        {
            _listNPC.Add(t.gameObject);
        }
        Instance = this;
        MainEndGame.Instance = mainEndGame;
        Question.Instance = question;
    }

    private void ResetNPC()
    {
        foreach (var t in _listNPC)
        {
            t.SetActive(true);
        }

        foreach (var k in playerControllers)
        {
            k.SetDefaultXY();
            k.gameObject.SetActive(false);
        }
    }

    public void NextChar()
    {
        _index++;
        SelectChar();
    }

    public void PreChar()
    {
        _index--;
        SelectChar();
    }

    private ManagerSounds Sound()
    {
        return ManagerSounds.Instance;
    }

    public void InterGame()
    {
        _lose = false;
        _point = 0;
        Sound().PlaySound("click");
        Question.Instance.CreateCauHoi();
        _isStart = true;
        ResetNPC();
        playerControllers[_index].gameObject.SetActive(true);
        cinemachineVirtualCamera.Follow = playerControllers[_index].transform;
        gameObject.SetActive(false);
        if(inputName.text.Length >= 1)
        {
            playerControllers[_index].SetNamePlayer(inputName.text);
        }
        Sound().PlaySound("soundgame");
    }

    public void SelectChar()
    {
        Sound().PlaySound("soundgame");
        if (_index == 0)
        {
            Sound().PlaySound("cow");
        }
        else if (_index == 1)
        {
            Sound().PlaySound("pig");
        }
        else
        {
            Sound().PlaySound("shark");
        }

        if (_index >= gameObPlayer.Count)
        {
            _index = 0;
        }
        else if (_index < 0)
        {
            _index = gameObPlayer.Count - 1;
        }

        for (int i = 0; i < gameObPlayer.Count; i++)
        {
            if (i == _index)
            {
                gameObPlayer[i].SetActive(true);
            }
            else
            {
                gameObPlayer[i].SetActive(false);
            }
        }
    }
}