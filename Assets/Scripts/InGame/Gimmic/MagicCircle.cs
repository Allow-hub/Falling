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
