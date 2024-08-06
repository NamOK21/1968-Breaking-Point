using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("---------- Audio Sources ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    [Header("------------ Audio Clips ------------")]
    public AudioClip background;
    public AudioClip gunfire;
    public AudioClip dies;
    public AudioClip fire;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
}
