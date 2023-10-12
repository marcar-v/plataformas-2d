using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] bool enableSelectCharacter;

    [SerializeField] enum Player { Frog, VirtualGuy, PinkMan };
    [SerializeField] Player playerSelected;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] RuntimeAnimatorController[] playersController;
    [SerializeField] Sprite[] playersRenderer;

    void Start()
    {
        if(!enableSelectCharacter)
        {
            ChangeSkinInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;

                case Player.PinkMan:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;

                case Player.VirtualGuy:
                    spriteRenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playersController[2];
                    break;

                default:
                    break;
            }
        }

    }

    public void ChangeSkinInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "NinjaFrog":
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;

            case "PinkMan":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;

            case "VirtualGuy":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;

            default:
                break;
        }
    }

}
