////////////////////////////////////////////////////////////////////////////////
//	Authors: Kaila Harris
//	Copyright © 2017 DigiPen (USA) Corp. and its owners. All Rights Reserved.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AudioVisualization
{
    public class AudioVisualManager : MonoBehaviour
    {
        // Static instance
        static AudioVisualManager _instance;

        public static AudioVisualManager GetInstance()
        {
            if (!_instance)
            {
                GameObject soundManager = new GameObject("AudioVisualManager");
                _instance = soundManager.AddComponent<AudioVisualManager>();
                _instance.Initialize();
            }

            return _instance;
        }


        const float MaxVolume_BGM = 1f;
        const float MaxVolume_SFX = 1f;
        static float CurrentVolumeNormalized_BGM = 1f;
        static float CurrentVolumeNormalized_SFX = 1f;
        static bool isMuted = false;

        List<AudioSource> sfxSources;
        AudioSource bgmSource;

        //List<Visuals> visuals;

        void Initialize()
        {
            // add our bgm sound source
            bgmSource = gameObject.AddComponent<AudioSource>();
            //gameObject.AddComponent<AudioLowPassFilter>();
            bgmSource.loop = true;
            bgmSource.playOnAwake = false;
            bgmSource.volume = GetBGMVolume();

            DontDestroyOnLoad(gameObject);
        }


        // ==================== Volume Getters =====================

        static float GetBGMVolume(float _volumeModifier = 0f)
        {
            return isMuted ? 0f : (MaxVolume_BGM + _volumeModifier) * CurrentVolumeNormalized_BGM;
        }

        public static float GetSFXVolume(float _volumeModifier = 0f)
        {
            return isMuted ? 0f : (MaxVolume_SFX + _volumeModifier) * CurrentVolumeNormalized_SFX;
        }


        // ====================== BGM Utils ======================

        void FadeBGMOut(float _fadeDuration)
        {
            AudioVisualManager soundMan = GetInstance();
            float delay = 0f;
            float toVolume = 0f;

            if (soundMan.bgmSource.clip == null)
            {
                Debug.LogError("Error: Could not fade BGM out as BGM AudioSource has no currently playing clip.");
            }

            StartCoroutine(FadeBGM(toVolume, delay, _fadeDuration));
        }

        void FadeBGMIn(AudioClip _bgmClip, float _delay, float _fadeDuration)
        {
            AudioVisualManager soundMan = GetInstance();
            soundMan.bgmSource.clip = _bgmClip;
            soundMan.bgmSource.Play();

            float toVolume = GetBGMVolume();

            StartCoroutine(FadeBGM(toVolume, _delay, _fadeDuration));
        }

        IEnumerator FadeBGM(float _fadeToVolume, float _delay, float _duration)
        {
            yield return new WaitForSeconds(_delay);

            AudioVisualManager soundMan = GetInstance();
            float elapsed = 0f;
            while (_duration > 0)
            {
                float t = (elapsed / _duration);
                float volume = Mathf.Lerp(0f, _fadeToVolume * CurrentVolumeNormalized_BGM, t); // "CurrentVolumeNormalized_BGM" was "CurrentVolumeModifier_BGM"
                soundMan.bgmSource.volume = volume;

                elapsed += Time.deltaTime;
                yield return 0;
            }
        }


        // ====================== BGM Functions ======================

        public static void PlayBGM(AudioClip _bgmClip, bool _fade, float _fadeDuration, float _volumeMod = 0f)
        {
            AudioVisualManager soundMan = GetInstance();

            if (_fade)
            {
                if (soundMan.bgmSource.isPlaying)
                {
                    // fade out, then switch and fade in
                    soundMan.FadeBGMOut(_fadeDuration / 2);
                    soundMan.FadeBGMIn(_bgmClip, _fadeDuration / 2, _fadeDuration / 2);

                }
                else
                {
                    // just fade in
                    float delay = 0f;
                    soundMan.FadeBGMIn(_bgmClip, delay, _fadeDuration);
                }
            }
            else
            {
                // play immediately
                soundMan.bgmSource.volume = GetBGMVolume(_volumeMod);
                soundMan.bgmSource.clip = _bgmClip;
                soundMan.bgmSource.Play();
            }
        }

        public static void StopBGM(bool _fade, float _fadeDuration)
        {
            AudioVisualManager soundMan = GetInstance();
            if (soundMan.bgmSource.isPlaying)
            {
                // fade out, then switch and fade in
                if (_fade)
                {
                    soundMan.FadeBGMOut(_fadeDuration);
                }
                else
                {
                    soundMan.bgmSource.Stop();
                }
            }
        }

        // ======================= SFX Utils ====================================

        AudioSource GetSFXSource(GameObject _obj = null, float _spacialBlend = 0f, float _volumeMod = 0f)
        {
            // set up a new sfx sound source for each new sfx clip
            AudioSource sfxSource;
            if (_obj == null)
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                sfxSource = _obj.AddComponent<AudioSource>();
            }

            sfxSource.loop = false;
            sfxSource.playOnAwake = false;
            sfxSource.spatialBlend = _spacialBlend;
            sfxSource.volume = GetSFXVolume(_volumeMod);

            if (sfxSources == null)
            {
                sfxSources = new List<AudioSource>();
            }

            sfxSources.Add(sfxSource);

            return sfxSource;
        }

        IEnumerator RemoveSFXSource(AudioSource _sfxSource)
        {
            yield return new WaitForSeconds(_sfxSource.clip.length);
            sfxSources.Remove(_sfxSource);
            Destroy(_sfxSource);
        }

        IEnumerator RemoveSFXSourceFixedLength(AudioSource _sfxSource, float _length)
        {
            yield return new WaitForSeconds(_length);
            sfxSources.Remove(_sfxSource);
            Destroy(_sfxSource);
        }

        // ====================== SFX Functions =================================

        public static void PlaySFX(AudioClip _sfxClip, GameObject _object = null, float _spacialBlend = 0f, float _volumeMod = 0f)
        {
            AudioVisualManager soundMan = GetInstance();
            AudioSource source = soundMan.GetSFXSource(_object, _spacialBlend, _volumeMod);
            source.volume = GetSFXVolume(_volumeMod);
            source.clip = _sfxClip;
            source.Play();

            soundMan.StartCoroutine(soundMan.RemoveSFXSource(source));
        }

        public static void PlaySFXRandomized(AudioClip _sfxClip, GameObject _object = null, float _spacialBlend = 0f, float _volumeMod = 0f, float _pitchMin = 0.85f, float _pitchMax = 1.2f)
        {
            AudioVisualManager soundMan = GetInstance();
            AudioSource source = soundMan.GetSFXSource(_object, _spacialBlend, _volumeMod);
            source.volume = GetSFXVolume(_volumeMod);
            source.clip = _sfxClip;
            source.pitch = Random.Range(_pitchMin, _pitchMax);
            source.Play();

            soundMan.StartCoroutine(soundMan.RemoveSFXSource(source));
        }

        public static void PlaySFXFixedDuration(AudioClip _sfxClip, float _duration, GameObject _object = null, float _spacialBlend = 0f, float _volumeMod = 0f, float _volumeMultiplier = 1.0f)
        {
            AudioVisualManager soundMan = GetInstance();
            AudioSource source = soundMan.GetSFXSource(_object, _spacialBlend, _volumeMod);
            source.volume = GetSFXVolume(_volumeMod) * _volumeMultiplier;
            source.clip = _sfxClip;
            source.loop = true;
            source.Play();

            soundMan.StartCoroutine(soundMan.RemoveSFXSourceFixedLength(source, _duration));
        }

        // ==================== Volume Control Functions ==========================

        public static void DisableSoundImmediate()
        {
            AudioVisualManager soundMan = GetInstance();
            soundMan.StopAllCoroutines();
            if (soundMan.sfxSources != null)
            {
                foreach (AudioSource source in soundMan.sfxSources)
                {
                    source.volume = 0;
                }
            }
            soundMan.bgmSource.volume = 0f;
            isMuted = true;
        }

        public static void EnableSoundImmediate()
        {
            AudioVisualManager soundMan = GetInstance();
            if (soundMan.sfxSources != null)
            {
                foreach (AudioSource source in soundMan.sfxSources)
                {
                    source.volume = GetSFXVolume();
                }
            }
            soundMan.bgmSource.volume = GetBGMVolume();
            isMuted = false;
        }

        public static void SetGlobalVolume(float _newVolume)
        {
            CurrentVolumeNormalized_BGM = _newVolume;
            CurrentVolumeNormalized_SFX = _newVolume;
            AdjustSoundImmediate();
        }

        public static void SetSFXVolume(float _newVolume)
        {
            CurrentVolumeNormalized_SFX = _newVolume;
            AdjustSoundImmediate();
        }

        public static void SetBGMVolume(float _newVolume)
        {
            CurrentVolumeNormalized_BGM = _newVolume;
            AdjustSoundImmediate();
        }

        public static void AdjustSoundImmediate()
        {
            AudioVisualManager soundMan = GetInstance();
            if (soundMan.sfxSources != null)
            {
                foreach (AudioSource source in soundMan.sfxSources)
                {
                    source.volume = GetSFXVolume();
                }
            }
            Debug.Log("BGMme: " + GetBGMVolume());
            soundMan.bgmSource.volume = GetBGMVolume();
            Debug.Log("BGMme is now: " + GetBGMVolume());
        }

        // ==================== Visualizer Functions ==========================

        //when creating/playing an audio source, have a boolean sent into the function
        //if the boolean is true, call a function from here to turn on/add a visual script to the object in question


        //put visualizer calls here
    }
}