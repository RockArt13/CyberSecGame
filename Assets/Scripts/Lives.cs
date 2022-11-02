using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public TMP_Text livesText;

    private void Update()
    {
        livesText.text = PlayerState.Lives + " LIVES";
        
    }
}
