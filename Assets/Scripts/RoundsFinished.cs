using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundsFinished : MonoBehaviour
{
    public TMP_Text roundText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerState.Rounds)
        {
            round++;
            roundText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }

}
