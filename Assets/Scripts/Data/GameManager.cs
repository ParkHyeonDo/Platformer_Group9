using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag;
    [SerializeField] private Image hpGause;
    public Player Player { get; private set; }
    public GameObject gameOverUI;

    private void Awake()
    { 
        if(Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Player>();
    }
    private void healthBar()
    {
        //hpGause.fillAmount = 
    }
}

