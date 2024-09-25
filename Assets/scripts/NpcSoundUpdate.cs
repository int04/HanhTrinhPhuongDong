using UnityEngine;

public class NpcSoundUpdate : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;

    private float _timeUpdate = 10;
    [SerializeField] private float timeSet = 1;

    private void Update()
    {
        if(_timeUpdate < timeSet)
        {
            _timeUpdate += Time.deltaTime;
            return;
        }
        if(audioSource == null)
        {
            return;
        }

        if(audioSource.isPlaying)
        {
            return;
        }

        var k = gameObject.transform.position;
        var player = StartGameControllers.Instance.GetCinemachineVirtualCamera().Follow;
        if (player)
        {
            var distance = Vector2.Distance(k, player.position);
            if(distance < 4)
            {
                _timeUpdate = 0;
                audioSource.Play();
            }
            else
            {
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