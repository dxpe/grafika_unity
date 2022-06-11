using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTraveled : MonoBehaviour
{
    public TextMeshProUGUI mText;
    public static int disRun;
    public bool addingDis = false;

    void Update()
    {
        if (addingDis == false && !PlayerMove.collided && PlayerMove.start) {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis() {
        disRun++;
        mText.text = "" + disRun;
        yield return new WaitForSeconds(0.25f);
        addingDis = false;
    }
}
