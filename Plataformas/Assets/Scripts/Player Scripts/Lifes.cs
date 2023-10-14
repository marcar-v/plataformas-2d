using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    [SerializeField] GameObject[] lifes;

    public void DeactivateLife(int index)
    {
        lifes[index].SetActive(false);
    }

    public void ActivateLife(int index)
    {
        lifes[index].SetActive(true);
    }
}
