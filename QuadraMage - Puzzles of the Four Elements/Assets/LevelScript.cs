using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Spust� prehr�vanie zvuku ka�d�ch 5 sek�nd od za?iatku hry
        InvokeRepeating("PlayAudio", 0f, 10f);
    }

    // Met�da pre prehr�vanie zvuku
    void PlayAudio()
    {
        if (audioSource.isPlaying)
        {
            // Zastav� prehr�vanie, ak u� prehr�va
            audioSource.Stop();
        }

        // Prehr� zvuk
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Va�a ?al�ia logika v Update
    }
}
