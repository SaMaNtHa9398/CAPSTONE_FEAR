
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("clips")]
    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    public AudioClip Walk;
    public AudioClip Running;
    public AudioClip Jumping;
    public AudioClip PickUp;
    public AudioClip PutDown;
    public AudioClip CollectTrinkets;
    public AudioClip NPCTalk;
    public AudioClip startingMatch;
    public AudioClip BurningFlame;
    public AudioClip FinalSoundEffect;
    public AudioClip Background;

    public void PlaySfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip); 
    }
}
