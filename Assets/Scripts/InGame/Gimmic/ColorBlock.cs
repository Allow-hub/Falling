using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorBlock : MonoBehaviour
{
    [SerializeField] Material objColor;
    [SerializeField] GameObject excellent;
    private Color color;
    [SerializeField] TextMeshProUGUI excellentText;
    private GameObject player;
    public enum PLAYER_NAME
    {
        Red,
        Blue,
        Green,
        Yellow
    }
    public PLAYER_NAME playerName;
    // Start is called before the first frame update
    void Start()
    {
       MeshRenderer meshRenderer=GetComponent<MeshRenderer>();
       meshRenderer.material = objColor;
       excellent.SetActive(false);
        
    }

    private void Update()
    {

    }

    public void DistanceEvent()
    {
        player = GameObject.FindWithTag("MainPlayer");

        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(distance < 10)
        {
            //StopCoroutine(Excellent());
            //StartCoroutine(Excellent());
        }
    }
    private IEnumerator Excellent()
    {
        if (excellent != null)
        {
            excellent.SetActive(true);

            // プレイヤー名に応じて色を設定
            switch (playerName)
            {
                case PLAYER_NAME.Red:
                    color = Color.red;
                    break;
                case PLAYER_NAME.Blue:
                    color = Color.blue;
                    break;
                case PLAYER_NAME.Green:
                    color = Color.green;
                    break;
                case PLAYER_NAME.Yellow:
                    color = Color.yellow;
                    break;
                default:
                    color = Color.white;
                    break;
            }

            excellentText.color = color;
            yield return new WaitForSeconds(0.5f);
            excellent.SetActive(false);
        }
        else
        {
            Debug.LogError("Excellent object is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainPlayer")&&other.gameObject.name==playerName.ToString())
        {
            Destroy(gameObject);
        }
    }
}
