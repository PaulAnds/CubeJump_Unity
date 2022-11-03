using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    [SerializeField]
    private Slider volumen_musica;
    [SerializeField]
    private AudioSource musica;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("volumen_musica"))
        {
            PlayerPrefs.SetFloat("volumen_musica", 1);
            volumen_musica.value = 1;
            musica.volume = 1;
            PlayerPrefs.Save();

        }
        else
        {
            musica.volume = PlayerPrefs.GetFloat("volumen_musica");
            volumen_musica.value = musica.volume;
            //Debug.Log(PlayerPrefs.GetFloat("volumen_musica") + "");
        }
    }
    public void volumen()
    {
        musica.volume = volumen_musica.value;
        PlayerPrefs.SetFloat("volumen_musica", volumen_musica.value);
        PlayerPrefs.Save();

        //Debug.Log(PlayerPrefs.GetFloat("volumen_musica") + "" );
    }
}
