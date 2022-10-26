using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TMP_Text moneyText;
    
    // Update is called once per frame
    void Update()
    {
        moneyText.text = '€' + PlayerState.Money.ToString();


    }
}
