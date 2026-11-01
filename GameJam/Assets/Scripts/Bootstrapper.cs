using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[DefaultExecutionOrder(-100)]
public class Bootstrapper : MonoBehaviour
{
    
    [Header("For audio service")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioMixer mixer;
    
    [SerializeField] AudioClip mainTheme;
    
    
    private void Awake()
    {
        ServiceLocator.Register<IAudioService>(new AudioService(source, null, mixer));
        ServiceLocator.Get<IAudioService>().PlayMusic(mainTheme);
    }
}
