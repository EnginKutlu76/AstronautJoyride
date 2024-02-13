using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text skorText, skorText2;
    public Text enYuksekSkorText;

    private int skor = 0;
    private int enYuksekSkor = 0;
    private string enYuksekSkorAnahtar = "EnYuksekSkor";

    void Start()
    {
        InvokeRepeating("ArtirVeGuncelle", 1f, 1f);
        enYuksekSkor = PlayerPrefs.GetInt(enYuksekSkorAnahtar, 0);
        GuncelleUI();
    }

    void ArtirVeGuncelle()
    {
        skor++;
        if (skor > enYuksekSkor)
        {
            enYuksekSkor = skor;
            PlayerPrefs.SetInt(enYuksekSkorAnahtar, enYuksekSkor);
            PlayerPrefs.Save();
        }
        GuncelleUI();
    }

    void GuncelleUI()
    {
        skorText2.text = "Score: " + skor;
        skorText.text = "Score: " + skor;
        enYuksekSkorText.text = "Highest Score: " + enYuksekSkor;
    }
}
