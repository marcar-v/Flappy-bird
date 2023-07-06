using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Columns"))
        {
            Destroy(gameObject);
        }
        if (collider.CompareTag("Player"))
        {
            GameController.instance.ItemScore();
            Destroy(gameObject);
        }

    }
}
