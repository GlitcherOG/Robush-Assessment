using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public bool SettingsOpen;
    public GameObject Panel;
    public bool menu;
    public Text volume;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
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

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        if(!menu)
        {
        if (SettingsOpen)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        }
    }

    public void Open()
    {
        SettingsOpen = !SettingsOpen;
        Panel.SetActive(SettingsOpen);
    }

    public void SetVolume(float soundLevel)
    {
        audioMixer.SetFloat("Volume", soundLevel);
        volume.text = "Master Volume: " + Mathf.Round((((80f+soundLevel)/80)*100)).ToString() + "%";
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
