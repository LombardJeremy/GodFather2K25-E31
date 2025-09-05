using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void MusicVolume()
    {
        audioManager.Instance.ChangeMusicVolume(_musicSlider.value * 80 - 80);
    }

    public void sfxVolume()
    {
        audioManager.Instance.ChangeSfxVolume(_sfxSlider.value * 80 - 80);
    }
}
