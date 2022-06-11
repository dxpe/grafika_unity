using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownRun;
    public GameObject restart;

    void Start()
    {
        StartCoroutine(CountSequence());
        restart.SetActive(false);
    }

    void Update() {
        if (PlayerMove.collided) {
            restart.SetActive(true);
        } else {
            restart.SetActive(false);
        }
    }

    IEnumerator CountSequence() {
        countDown3.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownRun.SetActive(true);
        PlayerMove.start = true;
    }
}
