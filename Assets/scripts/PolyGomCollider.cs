using UnityEngine;

public class PolyGomCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (StartGameControllers.Instance.GetLose()) return;
            if(Question.Instance.GetListQuestion() >= 1) return;
            MainEndGame.Instance.SetDiem("100");
            gameObject.SetActive(false);
        }
    }
}