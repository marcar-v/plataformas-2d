using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ChangeSkins : MonoBehaviour
{
    [SerializeField] GameObject player;

    public void SetPlayerNinjaFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "NinjaFrog");
        ResetPlayerSkin();
    }
    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        ResetPlayerSkin();
    }
    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        player.GetComponent<PlayerSelect>().ChangeSkinInMenu();
    }

}
