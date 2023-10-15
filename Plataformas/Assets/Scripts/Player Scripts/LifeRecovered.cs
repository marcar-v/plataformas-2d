using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRecovered : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bool lifeIsRecovered = GameController.instance.LifeRecovered();

            if(lifeIsRecovered)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
