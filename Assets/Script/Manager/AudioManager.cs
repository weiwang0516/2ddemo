using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    static AudioManager currentAudio;
    [Header("环境声音")]
    [SerializeField]
    private AudioClip ambientClip;
    [SerializeField]
    private AudioClip musucClip;

    [Header("Player音效")]
    [SerializeField]
    private AudioClip jumpClip;
    [SerializeField]
    private AudioClip[] runClip;
    [SerializeField]
    private AudioClip hitClip;

    [SerializeField]
    private AudioClip gunClip;

    AudioSource ambientSource;
    AudioSource musucSource;
    AudioSource playerRunSource;
    AudioSource playerJumpSource;
    AudioSource playerHitScoure;
    AudioSource gunSource;
    private void Awake()
    {
        if (currentAudio == null)
        {
            currentAudio = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        
        ambientSource = gameObject.AddComponent<AudioSource>();
        musucSource = gameObject.AddComponent <AudioSource>();
        playerRunSource = gameObject.AddComponent<AudioSource>();
        playerJumpSource = gameObject.AddComponent<AudioSource>();
        playerHitScoure = gameObject.AddComponent<AudioSource>();
        gunSource = gameObject.AddComponent<AudioSource>();
        AmbientAudio();
    }
    private void Update()
    {
        AmbientVolume();
    }
    public static void PlayerRunAudio()
    {
        int index = Random.Range(0, currentAudio.runClip.Length);
        currentAudio.playerRunSource.clip = currentAudio.runClip[index];
        currentAudio.playerRunSource.Play();
    }
    public static void GunAudio()
    {
        currentAudio.gunSource.clip = currentAudio.gunClip;
        currentAudio.gunSource.Play();
    }
    public static void PlayerJumpAudio()
    { 
        currentAudio.playerJumpSource.clip = currentAudio.jumpClip;
        currentAudio.playerJumpSource.Play();
    }

    public static void AmbientAudio()
    {
        currentAudio.ambientSource.clip = currentAudio.ambientClip;
        currentAudio.ambientSource.loop = true;
        currentAudio.ambientSource.Play();
    }

    static void AmbientVolume()
    {
        currentAudio.ambientSource.clip = currentAudio.ambientClip;
        currentAudio.ambientSource.volume = UImanager.instance.ambientSlider.value;

        currentAudio.gunSource.clip = currentAudio.gunClip;
        currentAudio.gunSource.volume = UImanager.instance.gunAudioSlider.value;

        currentAudio.playerJumpSource.clip = currentAudio.jumpClip;
        currentAudio.playerJumpSource.volume = UImanager.instance.playerSlider.value;

        currentAudio.playerHitScoure.clip = currentAudio.hitClip;
        currentAudio.playerHitScoure.volume = UImanager.instance.playerSlider.value;

        int index = Random.Range(0, currentAudio.runClip.Length);
        currentAudio.playerRunSource.clip = currentAudio.runClip[index];
        currentAudio.playerHitScoure.volume = UImanager.instance.playerSlider.value;

    }

    public static void PlayerHitAudio()
    {
        currentAudio.playerHitScoure.clip = currentAudio.hitClip;
        currentAudio.playerHitScoure.Play();
     
    }
}
