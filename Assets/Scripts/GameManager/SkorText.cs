using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorText : MonoBehaviour
{
    public Text skorText;
    private int skor = 0;
    public float timer = 1f;


    private void Start()
    {
        // �lk olarak, belirli bir s�re aral���nda UpdateScore() fonksiyonunu �a��rmaya ba�la.
        InvokeRepeating("UpdateScore", timer, timer);
    }

    private void UpdateScore()
    {
        skor++;
        UpdatePuanText();
    }
    void UpdatePuanText()
    {
        skorText.text = skor.ToString();
    }
}
