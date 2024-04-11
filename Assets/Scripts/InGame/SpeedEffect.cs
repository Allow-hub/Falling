using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SpeedEffect : MonoBehaviour
{
   
    [Header("References")]
    [SerializeField] private ScriptableRendererFeature fullScreenSpeed;
    [SerializeField] private Material material;

    [SerializeField] private GameObject volume;
    private void Start()
    {
        volume.SetActive(false);
        fullScreenSpeed.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.isMagic)
            {
                volume.SetActive(true);
                fullScreenSpeed.SetActive(true);

            }
            else if (!GameManager.Instance.isMagic)
            {
                volume.SetActive(false);
                fullScreenSpeed.SetActive(false);

            }
        }
    }
    

}
