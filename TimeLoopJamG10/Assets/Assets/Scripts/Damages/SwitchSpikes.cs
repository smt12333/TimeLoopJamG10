using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpikes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpikeUp;
    public float changeSpikeTime;

    private void Start()
    {
        InvokeRepeating("changeSpikeState", 0f, changeSpikeTime);
    }

    void changeSpikeState()
    {
        SpikeUp.SetActive(!SpikeUp.activeInHierarchy);
    }
}
