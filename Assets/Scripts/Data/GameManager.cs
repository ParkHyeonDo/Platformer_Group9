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
    public Player Player { get; private set; }
    [SerializeField] private Image hpGause;

    private void Awake()
    { 
        if(Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Player>();
    }
    public void Update()
    {
        hpGause.fillAmount = (float)Instance.Player.Stat.CharacterCurrentStat.Health/1000f;
    }
}

