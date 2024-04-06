using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float sensX;
    public float sensY;
    public static GameManager Instance => I;
    
    protected override void Init()
    {
        DontDestroyOnLoad(gameObject);  
        sensX = 200;
        sensY = 200;
    }
    public void SetSensVolume(float sensVolume)
    {
        sensX=sensVolume;
        sensY = sensVolume;
    }
}
