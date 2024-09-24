using System;
using UnityEngine;

public class SoundBallEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        var k = gameObject.transform.position;
        var player = StartGameControllers.Instance.GetCinemachineVirtualCamera().Follow;
        if (player)
        {
            var distance = Vector2.Distance(k, player.position);
            if(distance < 10)
            {
                audioSource.volume = 1 - distance / 10;
            }
            else
            {
                audioSource.volume = 0;
            }
        }
    }

    private void Awake()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}