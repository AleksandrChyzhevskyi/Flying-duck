using UnityEngine.UI;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    public AudioListener audioL;
    public Sprite musicON, musicOFF;
    private Image butten;
    

    private void Awake()
    {
        butten = GetComponent<Image>();
        if (PlayerPrefs.GetString("music") == "off")
        {
            butten.sprite = musicOFF;
            audioL.enabled = false;
        }
    }    
    public void setMusic()
    {
        audioL.enabled = !audioL.enabled;

        if (audioL.enabled)
        {
            butten.sprite = musicON;
            PlayerPrefs.SetString("music", "on");
        }
        else
        {
            butten.sprite = musicOFF;
            PlayerPrefs.SetString("music", "off");
        }
    }
}
