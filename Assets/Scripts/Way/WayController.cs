using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayController : MonoBehaviour
{
    private bool yolYapildi = false;
    public GameObject[] way;

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Player" && yolYapildi == false)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x + 20, 0, 0);
            int randomIndex = Random.Range(0, way.Length);
            Destroy(gameObject, 1f);
            Instantiate(way[randomIndex], spawnLocation, Quaternion.identity);
            yolYapildi = true;
        }
    }
}
