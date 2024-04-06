using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMove : MonoBehaviour
{
    [SerializeField] Player player;
    private void Update()
    {
        Move(gameObject);
        Debug.Log(player.move);
    }
    private void Move(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = player.move;

    }
}
