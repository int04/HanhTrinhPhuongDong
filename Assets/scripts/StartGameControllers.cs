using System;
using System.Collections.Generic;
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

    private void Awake()
    {
        foreach (Transform t in transformNPC.transform)
        {
            _listNPC.Add(t.gameObject);
        }
    }

    private void ResetNPC()
    {
        foreach (var t in _listNPC)
        {
            t.SetActive(true);
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

    public void InterGame()
    {
        ResetNPC();
    }

    public void SelectChar()
    {
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