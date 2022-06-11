using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        CollectableCoin.coinCount++;
        coinFX.Play();
        this.gameObject.SetActive(false);
    }
}
