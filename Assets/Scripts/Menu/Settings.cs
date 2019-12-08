using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public class Settings : MonoBehaviour
{
    public Text volumeText;
    public Dropdown resolutionDropdown;
    public Dropdown quailtyDropdown;
    public Slider volumeSlider;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    public float volume;
    public KeyCode tempKey, forward, backward, left, right, inventory, interact, jump;
    public Text forwardButton, backwardButton, leftButton, rightButton, inventoryButton, interactButton, jumpButton;
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
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.forward);
        forwardButton.text = forward.ToString();
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.backward);
        backwardButton.text = backward.ToString();
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.left);
        leftButton.text = left.ToString();
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.right);
        rightButton.text = right.ToString();
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.jump);
        jumpButton.text = jump.ToString();
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.interact);
        interactButton.text = interact.ToString();
        inventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), data.inventory);
        inventoryButton.text = inventory.ToString();
    }

    public void Forward()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = forward;
            forward = KeyCode.None;
        }
        forwardButton.text = forward.ToString();
    }

    public void Backward()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = backward;
            backward = KeyCode.None;
        }
        backwardButton.text = backward.ToString();
    }
    public void Left()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = left;
            left = KeyCode.None;
        }
        leftButton.text = left.ToString();
    }

    public void Right()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = right;
            right = KeyCode.None;
        }
        rightButton.text = right.ToString();
    }
    public void Inventory()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = inventory;
            inventory = KeyCode.None;
        }
        inventoryButton.text = inventory.ToString();
    }
    public void Interact()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = interact;
            backward = KeyCode.None;
        }
        interactButton.text = interact.ToString();
    }
    public void Jump()
    {
        if (tempKey == KeyCode.None)
        {
            tempKey = jump;
            jump = KeyCode.None;
        }
        jumpButton.text = jump.ToString();
    }
    private void OnGUI()
    {
        Debug.Log(forward);
        Event e = Event.current;
        if (tempKey != KeyCode.None)
        {
            if (forward == KeyCode.None)
            {
                if (e.keyCode != backward)
                {
                    forward = e.keyCode;
                    forwardButton.text = forward.ToString();
                }
                else
                {
                    forward = tempKey;
                    forwardButton.text = forward.ToString();
                }
            }
            else
        if (backward == KeyCode.None)
            {
                if (e.keyCode != forward)
                {
                    backward = e.keyCode;
                    backwardButton.text = backward.ToString();
                }
                else
                {
                    backward = tempKey;
                    backwardButton.text = backward.ToString();
                }
            }
            else
        if (left == KeyCode.None)
            {
                if (e.keyCode != right)
                {
                    left = e.keyCode;
                    leftButton.text = left.ToString();
                }
                else
                {
                    left = tempKey;
                    leftButton.text = left.ToString();
                }
            }
            else
        if (right == KeyCode.None)
            {
                if (e.keyCode != left)
                {
                    right = e.keyCode;
                    rightButton.text = right.ToString();
                }
                else
                {
                    right = tempKey;
                    rightButton.text = right.ToString();
                }
            }
            else
        if (interact == KeyCode.None)
            {
                interact = e.keyCode;
                interactButton.text = interact.ToString();
            }
            else
        if (inventory == KeyCode.None)
            {
                inventory = e.keyCode;
                inventoryButton.text = inventory.ToString();
            }
            else
        if (jump == KeyCode.None)
        {
                jump = e.keyCode;
                jumpButton.text = jump.ToString();
            }
            else
            {
                tempKey = KeyCode.None;
            }
        }
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
