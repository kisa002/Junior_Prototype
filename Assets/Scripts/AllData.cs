using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllData : MonoBehaviour {

    private int playerHp;
    private int score;
    private int enemyNum;

    private static AllData instance;
    public static AllData GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<AllData>();
            if(instance = null)
            {
                GameObject container = new GameObject("AllData");
                instance = container.AddComponent<AllData>();
            }
        }
        return instance;
    }

    public int GetPlayerHp()
    {
        return playerHp;
    }
    public void SetPlayerHp(int playerHp)
    {
        this.playerHp = playerHp;
    }
    public void AddPlayerHp(int playerHp)
    {
        this.playerHp += playerHp;
        SetPlayerHp(this.playerHp);
    }
    public void SubPlayerHp(int playerHp)
    {
        this.playerHp -= playerHp;
        SetPlayerHp(this.playerHp);
    }

    public int GetScore()
    {
        return score;   
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
    public void AddScore(int score)
    {
        this.score += score;
        SetScore(this.score);
    }
    public void SubScore(int score)
    {
        this.score -= score;
        SetScore(this.score);
    }

    public int GetEnemyNum()
    {
        return enemyNum;
    }
    public void SetEnemyNum(int enemyNum)
    {
        this.enemyNum = enemyNum;
    }
    public void AddEnemyNum(int enemyNum)
    {
        this.enemyNum += enemyNum;
        SetEnemyNum(this.enemyNum);
    }
    public void SubEnemyNum(int enemyNum)
    {
        this.enemyNum -= enemyNum;
        SetEnemyNum(this.enemyNum);
    }

}
