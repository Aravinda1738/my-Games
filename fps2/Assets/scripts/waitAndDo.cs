using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitAndDo : MonoBehaviour
{
    public GameObject ui;
    public float waitFor;
    public void Start()
    {
        StartCoroutine(change());
    }

    public IEnumerator change()
    {
        yield return new WaitForSeconds(waitFor);
        ui.SetActive(true);
        Time.timeScale = 0;
    }
}
