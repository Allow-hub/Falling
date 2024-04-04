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
        titleBGM.Play();
    }

    public void firstStage()
    {
        titleBGM.Stop();
        firstStageBGM.Play();
    }
}
