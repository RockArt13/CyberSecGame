using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    public int startMoney = 500;
    public int startLives = 10;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }


}
