// +
using UnityEngine;

public class SpikeFloor : MonoBehaviour, IDamaging
{
    private GameObject player; 
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == player.name) 
        {
            player.GetComponent<Player>().health.SubtractHealth(1);
        }
    }
}