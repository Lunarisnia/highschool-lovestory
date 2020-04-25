using System.Collections;
using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    [SerializeField] private Player player;
    public TextMeshProUGUI clock;
    Coroutine clockRoutine;
    private void Start()
    {
        clockRoutine = StartCoroutine(startClock());
    }
    IEnumerator startClock()
    {
        while (true)
        {
            if (player.hour < 12)
            {
                clock.text = string.Format("{0}:{1} am", LeadingZero(player.hour), LeadingZero(player.sec));
            }
            else
            {
                clock.text = string.Format("{0}:{1} pm", LeadingZero(player.hour), LeadingZero(player.sec));
            }

            yield return new WaitForSeconds(1.5f);
            player.sec++;
            if (player.sec == 60)
            {
                player.hour++;
                player.sec = 0;
            }
            if (player.hour > 24)
            {
                player.hour = 0;
            }
        }
    }

    string LeadingZero(int number)
    {
        return number.ToString().PadLeft(2, '0');
    }
}
