using System;
using TMPro;
using UnityEngine;

public class MainEndGame : MonoBehaviour
{
    public static MainEndGame Instance;
    private string _oldText = "";
    [SerializeField] private TextMeshProUGUI diem, text;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _oldText = text.text;
    }

    public void SetDiem(string m)
    {
        var q = _oldText;
        q = q.Replace("{0}", StartGameControllers.Instance.GetNamePlayer());
        text.text = q;
        diem.text = m;
        End();
    }

    public void End()
    {
        StartGameControllers.Instance.SetNoCamera();
        ManagerSounds.Instance.PlaySound("win");
    }
    public void TiepTuc()
    {
        StartGameControllers.Instance.SetHaveCameraFromIndex();
        gameObject.SetActive(false);
    }

    public void KetThuc()
    {
        gameObject.SetActive(false);
        StartGameControllers.Instance.MenuChinh();
    }

    private void Update()
    {
        StartGameControllers.Instance.MoveUpdateForm();
    }
}