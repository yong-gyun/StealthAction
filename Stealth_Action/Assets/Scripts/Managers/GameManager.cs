using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public Define.CardKey Type;
    public int Count;

    public Item(Define.CardKey type, int count)
    {
        Type = type;
        Count = count;
    }
}

public class GameManager
{
    GameObject _player;
    public GameObject GetPlayer() 
    {
        if (_player == null)
            _player =GameObject.Find("Player");

        return _player; 
    }

    public List<EnemyController> EnemyList = new List<EnemyController>();
    public List<Item> KeyInventory = new List<Item>();

    public void Init()
    {
        for (int i = 0; i < (int) Define.CardKey.MaxCount; i++)
        {
            KeyInventory.Add(new Item((Define.CardKey) i, 0));
        }
    }
}
