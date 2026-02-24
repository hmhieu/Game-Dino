using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip tapClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip crackEggClip;
    private bool hasPLayEffectSound = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }  
    }
    public bool hasPlayEffectSound()
    {
        return hasPLayEffectSound;
    }
    public void SetHasPlayEffectSound(bool value)
    {
        hasPLayEffectSound = value;
    }


    void Start()
    {
        effectSource.Stop();
        hasPLayEffectSound = true;
    }
    public void PlayJumpClip()
    {
        effectSource.PlayOneShot(jumpClip);
    }
    public void PlayTapClip()
    { 
        effectSource.PlayOneShot(tapClip);     
    }
    public void PlayHurtClip()
    {
        effectSource.PlayOneShot(hurtClip);
    }
    public void PlayCrackEggClip()
    {
        effectSource.PlayOneShot(crackEggClip);
    }


}
