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

        // Spustí prehrávanie zvuku každých 5 sekúnd od za?iatku hry
        InvokeRepeating("PlayAudio", 0f, 10f);
    }

    // Metóda pre prehrávanie zvuku
    void PlayAudio()
    {
        if (audioSource.isPlaying)
        {
            // Zastaví prehrávanie, ak už prehráva
            audioSource.Stop();
        }

        // Prehrá zvuk
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Vaša ?alšia logika v Update
    }
}
