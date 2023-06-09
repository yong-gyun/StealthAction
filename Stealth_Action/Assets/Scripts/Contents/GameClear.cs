using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Managers.UI.ShowPopupUI<UI_GameClear>();
            Managers.Sound.Play("Bgm/Clear", Define.Sound.Bgm);
        }
    }
}