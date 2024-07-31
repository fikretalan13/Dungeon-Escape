using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool HasKeyToCastle { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

}
