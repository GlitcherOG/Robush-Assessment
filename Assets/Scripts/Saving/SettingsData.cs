[System.Serializable]
public class SettingsData
{
    public int quailtyIndex;
    public int resolutionIndex;
    public float soundLevel;

    public SettingsData(Settings settings)
    {
        quailtyIndex = settings.quailtyDropdown.value;
        resolutionIndex = settings.resolutionDropdown.value;
        soundLevel = settings.volumeSlider.value;
    }
}
