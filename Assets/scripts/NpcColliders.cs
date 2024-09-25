using System;
using TMPro;
using UnityEngine;

public class NpcColliders : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private string setTextName = "";

    private void Start()
    {
        if (setTextName.Length >= 1)
        {
            textName.text = setTextName;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Question.Instance.VaChamNPC(gameObject);
        }
    }

}