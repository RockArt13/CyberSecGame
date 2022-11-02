using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    public int startMoney = 500;
    public int startLives = 10;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }


}
