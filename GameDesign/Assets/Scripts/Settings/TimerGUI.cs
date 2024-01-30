using UnityEngine;
using TMPro;

public class TimerGUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _display;

    private void LateUpdate()
    {
        int minutes = (int)(GameProgress.Timer / 60f);
        int seconds = (int)(GameProgress.Timer - (minutes * 60));
        _display.text = $"{minutes} : " + (seconds < 10? "0" : "") + $"{seconds}";
    }
}