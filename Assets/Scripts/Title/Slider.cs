using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
        BGMManager.Instance.SetBGMVolume(volume);
    }
    public void SetSEVolume(float volume)
    {
       // BGMManager.Instance.SetBGMVolume(volume);
    }
    public void SetSensVolume(float volume)
    {
        GameManager.Instance.SetSensVolume(volume);
    }

}
