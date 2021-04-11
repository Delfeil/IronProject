using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AusioClips")]
    [SerializeField] public AudioClip play;
    [SerializeField] public AudioClip preview;
    [SerializeField] public AudioClip stop;
    [SerializeField] public AudioClip victory;
    [SerializeField] public AudioClip gameOver;
    [SerializeField] public AudioClip playerMove;
    [SerializeField] public AudioClip ennemyMove;
    AudioSource audioSource;

    public static AudioManager Instance;
    private void Awake() //Make this a singleton
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.Play:
                audioSource.PlayOneShot(play);
                break;
            case SoundType.Preview:
                audioSource.PlayOneShot(preview);
                break;
            case SoundType.Stop:
                audioSource.PlayOneShot(stop);
                break;
            case SoundType.Victory:
                audioSource.PlayOneShot(victory);
                break;
            case SoundType.GameOver:
                audioSource.PlayOneShot(gameOver);
                break;
            case SoundType.PlayerMove:
                audioSource.PlayOneShot(playerMove);
                break;
            case SoundType.EnnemyMove:
                audioSource.PlayOneShot(ennemyMove);
                break;
        }
    }
}
