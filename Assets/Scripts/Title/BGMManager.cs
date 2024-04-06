using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    public static BGMManager Instance=>I;

    public AudioSource titleBGM;
    public AudioSource firstStageBGM;
    // Start is called before the first frame update

    protected override void Init()
    {
        base.Init();
        DontDestroyOnLoad(gameObject);
        if (titleBGM == null) return;
        titleBGM.Play();
    }

    public void firstStage()
    {
        if (titleBGM == null|| firstStageBGM==null) return;

        titleBGM.Stop();
        firstStageBGM.Play();
    }
    public void SetBGMVolume(float volume)
    {
        titleBGM.volume = volume;
        firstStageBGM.volume=volume;
    }
}
