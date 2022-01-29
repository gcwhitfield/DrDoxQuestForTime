using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovesRemainingIndicator : Singleton<MovesRemainingIndicator>
{
    public TMP_Text movesRemainingText;

    public void ShowMoveIndicator(int movesRemaining)
    {
        movesRemainingText.text = movesRemaining.ToString();
    }
}
