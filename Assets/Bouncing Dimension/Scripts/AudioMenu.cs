using UnityEngine;
using UnityEngine.UI;
public class AudioMenu : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public Slider menuVolumeSlider;
    [SerializeField] GameObject audioDetector;

    enum State { On, Off };
    State state;

    void Start()
    {
        menuVolumeSlider.value = menuVolumeSlider.maxValue;
        audioSource.volume = menuVolumeSlider.value;

        menuVolumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void Music(AudioClip clip)
    {
        if (state == State.On && audioSource != null && clip != null)
        {

            audioDetector.SetActive(false);
            state = State.Off;
            audioSource.clip = clip;
            audioSource.Stop();
        }

        else if (state == State.Off && audioSource != null && clip != null)
        {

            audioDetector.SetActive(true);
            state = State.On;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


    void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
