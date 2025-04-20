using UnityEngine;
using UnityEngine.UI;

public class SoundManagerGame1 : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }

        Load(); // Panggil Load() tetap di luar if supaya selalu sinkron
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        float volume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = volume;
        AudioListener.volume = volume; // <--- INI dia bagian pentingnya
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
