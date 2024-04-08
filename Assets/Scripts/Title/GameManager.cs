using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float sensX;
    public float sensY;
    public int life;
    public bool gameOver=false;
    public static GameManager Instance => I;
    
    protected override void Init()
    {
        DontDestroyOnLoad(gameObject); 
        life = 0;
        sensX = 200;
        sensY = 200;
    }
    public void SetSensVolume(float sensVolume)
    {
        sensX=sensVolume;
        sensY = sensVolume;
    }
    public void Damage(int damage)
    {
        life-=damage;
        if(life <= 0)
        {
            life = 0;
            gameOver=true;
        }
    }
}
