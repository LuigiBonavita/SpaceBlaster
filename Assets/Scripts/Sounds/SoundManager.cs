using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip EnvironmentClip;
    public AudioClip OnShoot;
    public AudioClip OnBulletDestroyClip;
    public AudioClip OnShipDestroy;

    //avere come minimo il suono per la musica e per gli effetti
    public AudioSource EnvironmentTrack;
    public AudioSource SFXTrack;
    private AudioClip _audioClip;

    // Use this for initialization
    void Start ()
    {
        EnvironmentTrack.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #region Event +/- Subscription
    private void OnEnable()
    {
        BulletPoolManager.OnBulletInGame += OnBulletInGame;
    }

    private void OnDisable()
    {
        BulletPoolManager.OnBulletInGame -= OnBulletInGame;
    }
    #endregion

    private void OnBulletInGame(IBullet _IBullet)
    {
        _IBullet.OnDestroy += OnBulletDestroy;
    }

    private void OnBulletDestroy(IBullet bullet)
    {
        SetSFXTrackAndPlay(OnBulletDestroyClip);
        bullet.OnDestroy -= OnBulletDestroy;
    }

    public void SetEnvironmentClip()
    {
        EnvironmentTrack.clip = EnvironmentClip;
        EnvironmentTrack.loop = true;
        EnvironmentTrack.Play();
    }

    public void SetSFXTrackAndPlay(AudioClip audioClip)
    {
        SFXTrack.clip = _audioClip;
        SFXTrack.Play();
    }
}
