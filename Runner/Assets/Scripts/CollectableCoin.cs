using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableCoin : MonoBehaviour
{
    public static int coinCount;
    public TextMeshProUGUI mText;

    void Update()
    {
        mText.text = "" + coinCount;
    }
}
