using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    [SerializeField] Material objColor;

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
            Debug.Log(distance);
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
