using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static ColorBlock;

public class MagicCircle : MonoBehaviour
{
    VisualEffect effect;
    [SerializeField] float changingDistance=70;
    [SerializeField] float size;
    [SerializeField] float targetValue = 40f;
    [SerializeField] float duration = 1f;
    [SerializeField] bool isRandom = false;
    [ColorUsage(true, true)]
    public Color redColor,blueColor,greenColor,yellowColor;
    private float elapsedTime = 0f;
    private GameObject player;
    public enum PLAYER_NAME
    {
        Red,
        Blue,
        Green,
        Yellow
    }
    public PLAYER_NAME playerName;

    private void Start()
    {
        effect = GetComponent<VisualEffect>();
        size = 0;

        effect.SetFloat("size", size);
        if(isRandom)
        {
            int r = 0;
            r=Random.Range(0, 4);
            switch(r)
            {
                case 0:
                    effect.SetVector4("Magic", redColor);
                    playerName = PLAYER_NAME.Red;
                    break; 
                case 1:
                    effect.SetVector4("Magic", blueColor);
                    playerName = PLAYER_NAME.Blue;
                    break;
                case 2:
                    effect.SetVector4("Magic", greenColor);
                    playerName = PLAYER_NAME.Green;
                    break;  
                case 3:
                    effect.SetVector4("Magic", yellowColor);
                    playerName = PLAYER_NAME.Yellow;
                    break;
                default:
                    effect.SetVector4("Magic", redColor);
                    playerName = PLAYER_NAME.Red;
                    Debug.Log(gameObject.name + "ÇÃêFÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
                    break;
            }
        }else if (!isRandom)
        {
            switch (playerName)
            {
                case PLAYER_NAME.Red:
                    effect.SetVector4("Magic", redColor);
                    playerName = PLAYER_NAME.Red;
                    break; 
                case PLAYER_NAME.Blue:
                    effect.SetVector4("Magic", blueColor);
                    playerName = PLAYER_NAME.Blue;
                    break;
                case PLAYER_NAME.Green:
                    effect.SetVector4("Magic", greenColor);
                    playerName = PLAYER_NAME.Green;
                    break;
                case PLAYER_NAME.Yellow:
                    effect.SetVector4("Magic", yellowColor);
                    playerName = PLAYER_NAME.Yellow;
                    break;
                    default:
                    effect.SetVector4("Magic", redColor);
                    playerName = PLAYER_NAME.Red;
                    Debug.Log(gameObject.name+"ÇÃêFÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
                    break;
            }
        }
    }
    private void Update()
    {
        DistanceEvent();
    }
    public void DistanceEvent()
    {

        player = GameObject.FindWithTag("MainPlayer");
        if (player == null) return;
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distance < changingDistance)
        {

            if (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                size = Mathf.Lerp(0f, targetValue, elapsedTime / duration);
            }
            effect.SetFloat("size", size);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainPlayer") && other.gameObject.name == playerName.ToString())
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("MainPlayer") && other.gameObject.name != playerName.ToString())
        {
            if (GameManager.Instance == null) return;
            StopAllCoroutines();
            StartCoroutine(Magic());
        }
    }
    private IEnumerator Magic()
    {
        GameManager.Instance.isMagic = true;
        yield return new WaitForSeconds(3f);
        GameManager.Instance.isMagic = false;

        Destroy(gameObject);

    }
}
