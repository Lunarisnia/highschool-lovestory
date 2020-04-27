using System.Collections;
using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    // [SerializeField] private Player Player;
    public TextMeshProUGUI clock;
    public Coroutine clockRoutine;
    private void Start()
    {
        clockRoutine = StartCoroutine(startClock());
    }
    IEnumerator startClock()
    {
        while (true)
        {
            if (Player.hour < 12)
            {
                clock.text = string.Format("{0}:{1} AM", LeadingZero(Player.hour), LeadingZero(Player.sec));
            }
            else
            {
                clock.text = string.Format("{0}:{1} PM", LeadingZero(Player.hour), LeadingZero(Player.sec));
            }

            yield return new WaitForSeconds(1.5f);
            Player.sec++;
            if (Player.sec == 60)
            {
                Player.hour++;
                Player.sec = 0;
            }
            if (Player.hour >= 24)
            {
                Player.hour = 0;
            }
        }
    }

    string LeadingZero(int number)
    {
        return number.ToString().PadLeft(2, '0');
    }
}
