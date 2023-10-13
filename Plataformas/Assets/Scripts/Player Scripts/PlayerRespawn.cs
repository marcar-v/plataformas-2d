using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject transition;

    [Header("Life Counter")]
    [SerializeField] GameObject[] lifes;
    private int life;


    private void Start()
    {
        life = lifes.Length;
    }
    private void CheckLife()
    {
        if(life < 1)
        {
            Destroy(lifes[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(life < 2) 
        {
            Destroy(lifes[1].gameObject);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            Destroy(lifes[2].gameObject);
            animator.Play("Hit");
        }
    }

    public void PlayerDamaged()
    {
        life--;
        CheckLife();
    }
}
