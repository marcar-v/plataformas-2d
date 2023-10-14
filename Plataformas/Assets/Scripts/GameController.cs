using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] GameObject transition;

    [Header("Life Counter")]
    [SerializeField] GameObject[] lifes;
    private int life;

    public static GameController instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Cuidado, más de un Game Manager en escena.");
        }
    }

    private void Start()
    {
        life = lifes.Length;
    }
    public void DeactivateLife(int index)
    {
        lifes[index].SetActive(false);
    }

    public void ActivateLife(int index)
    {
        lifes[index].SetActive(true);
    }

    public void PlayerDamaged()
    {
        life -= 1;
        animator.Play("Hit");
        if (life == 0)
        {
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        DeactivateLife(life);

    }

    public bool LifeRecovered()
    {
        if (life == 3)
        {
            return false;
        }
        ActivateLife(life);
        life += 1;

        return true;
    }
}
