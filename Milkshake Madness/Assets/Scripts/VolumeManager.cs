using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public Slider volumeSlider;

    AudioSource audioSource;

    private float currentVolume;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        setVolumeValue(currentVolume);
    }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!audioSource.playOnAwake)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    void OnEnable()
    {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
        currentVolume = sliderValue;
    }

    void setVolumeValue(float amount)
    {
        // set slider to current amount
        volumeSlider.value = amount;
    }

    void OnDisable()
    {
        //Un-Register Slider Events
        volumeSlider.onValueChanged.RemoveAllListeners();
    }
}