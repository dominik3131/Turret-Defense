using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForwardManager : MonoBehaviour
{
    public Button fastForwardButton;
    private bool fastForwarded = false;
    // Start is called before the first frame update
    void Start()
    {
        fastForwardButton.onClick.AddListener(FastForward);
    }

    void FastForward()
    {
        if ( fastForwarded )
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 2;
        }
        fastForwarded = !fastForwarded;
    }
}
