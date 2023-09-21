using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    [SerializeField] GameObject transition;
    [SerializeField] TextMeshProUGUI totalFruits;
    [SerializeField] TextMeshProUGUI fruitsCollected;

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = (totalFruitsInLevel - transform.childCount).ToString();
    }

    public void AllFruitsCollected()
    {
        if(transform.childCount == 0)
        {
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
