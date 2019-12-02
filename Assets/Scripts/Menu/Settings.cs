using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public class Settings : MonoBehaviour
{
    public bool menu;
    public Text volumeText;
    public Dropdown resolutionDropdown;
    public Dropdown quailtyDropdown;
    public Slider volumeSlider;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        quailtyDropdown.value = QualitySettings.GetQualityLevel();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        if (SettingsBinary.LoadSettingsData() != null)
        {
            Load();
        }
        else
        {
            Save();
        }
    }

    public void Load()
    {
        SettingsData data = SettingsBinary.LoadSettingsData();
        audioMixer.SetFloat("Volume", data.soundLevel);
        volumeText.text = "Master Volume: " + Mathf.Round((((80f + data.soundLevel) / 80) * 100)).ToString() + "%";
        resolutionDropdown.value = data.resolutionIndex;
        quailtyDropdown.value = data.quailtyIndex;
        QualitySettings.SetQualityLevel(data.quailtyIndex);
        Resolution resolution = resolutions[data.resolutionIndex];
        volumeSlider.value = data.soundLevel;
    }

    public void Save()
    {
        SettingsBinary.SaveSettingData(this);
    }

    public void SetVolume(float soundLevel)
    {
        audioMixer.SetFloat("Volume", soundLevel);
        Debug.Log(soundLevel);
        volumeText.text = "Master Volume: " + Mathf.Round((((80f + soundLevel) / 80) * 100)).ToString() + "%";
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuailty(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
    }
}
