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
        print("va chạm với" + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            print("va chạm với player");
            Question.Instance.VaChamNPC();
        }
    }

}