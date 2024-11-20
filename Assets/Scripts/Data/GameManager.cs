using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag;
    public PlayerController Player { get; private set; }

    private void Awake()
    { 
        if(Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<PlayerController>();
    }

}

