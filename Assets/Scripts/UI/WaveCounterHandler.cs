using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounterHandler : MonoBehaviour
{
    private Text waveCounter;
    private GameObject gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        waveCounter = gameObject.GetComponentInChildren<Text>();
        gameMaster = GameObject.Find("/GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        waveCounter.text="Enemies wave:" + gameMaster.GetComponentInChildren<WaveSpanner>().getWaveNumber();
    }
}
