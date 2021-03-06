using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    private AudioSource manager;
    private AudioSource ownManager;
    private AudioSource dManager;
    private bool playerDied = false;
    private bool loopisplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        ownManager = transform.GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("loop").transform.GetComponent<AudioSource>();
        dManager = GameObject.FindGameObjectWithTag("DedSong").transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ownManager.time >=ownManager.clip.length-0.1f && !loopisplaying)
        {
            print("a");
            manager.volume = ownManager.volume;
            manager.Play();
            loopisplaying = true;
        }
    }
    public void playerDED() 
    {
        if (!playerDied) 
        {
            print("sadgeMusic");
            dManager.volume = ownManager.volume;
            ownManager.Stop();
            manager.Stop();
            dManager.Play();
            loopisplaying = true;
            playerDied = true;
        }
    }
    private void OnEnable()
    {
        loopisplaying = false;
        ownManager = transform.GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("loop").transform.GetComponent<AudioSource>();
        dManager = GameObject.FindGameObjectWithTag("DedSong").transform.GetComponent<AudioSource>();
    }
}
