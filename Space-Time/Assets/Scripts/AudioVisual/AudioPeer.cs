using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace AudioPeerViz
//{
    //[RequireComponent(typeof(AudioSource))]
    public class AudioPeer : MonoBehaviour
    {
        public static AudioPeer instance;
        AudioSource audioSource;

        private float[] samplesLeft = new float[512];
        private float[] samplesRight = new float[512];

        // audio 8-band
        private float[] freqBand = new float[8];
        private float[] bandBuffer = new float[8];
        private float[] bufferDecrease = new float[8];
        private float[] freqBandHighest = new float[8];
        
        [HideInInspector]
        public float[] audioBand, audioBandBuffer;

        [HideInInspector]
        public float amplitude, amplitudeBuffer;
        private float amplitudeHighest;
        public float audioProfile;

        [Range(0,7)]
        public int bandNumber = 6;
        public static float GlobalScaler { 
            get { return instance.freqBand[instance.bandNumber] / 500; }
        }

        public enum Channel { Stereo, Left, Right };
        public Channel channel = new Channel();

        private void Awake()
        {
            instance = this;
        }

    // Use this for initialization
    void Start()
        {
            audioBand = new float[8];
            audioBandBuffer = new float[8];

            audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
                audioSource = SoundHub.source_bgm;

            AudioProfile(audioProfile);
        }

        // Update is called once per frame
        void Update()
        {
            GetSpectrumAudioSource();
            MakeFrequencyBands();
            BandBuffer();
            CreateAudioBands();
            GetAmplitude();
        }

        void AudioProfile(float _audioProfile)
        {
            for (int i = 0; i < 8; i++)
            {
                freqBandHighest[i] = _audioProfile;
            }
        }

        void GetAmplitude()
        {
            float currentAplitude = 0;
            float currentAplitudeBuffer = 0;
            for (int i = 0; i < 8; i++)
            {
                currentAplitude += audioBand[i];
                currentAplitudeBuffer += audioBandBuffer[i];
            }
            if (currentAplitude > amplitudeBuffer)
                amplitudeHighest = currentAplitude;
            amplitude = currentAplitude / amplitudeHighest;
            amplitudeBuffer = currentAplitudeBuffer / amplitudeHighest;
        }

        void CreateAudioBands()
        {
            for (int i = 0; i < 8; i++)
            {
                if (freqBand[i] > freqBandHighest[i])
                {
                    freqBandHighest[i] = freqBand[i];
                }
                audioBand[i] = (freqBand[i] / freqBandHighest[i]);
                audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);

            }
        }
        
        void GetSpectrumAudioSource()
        {
            audioSource.GetSpectrumData(samplesLeft, 0, FFTWindow.Rectangular);
            audioSource.GetSpectrumData(samplesRight, 1, FFTWindow.Rectangular);
        }

        void BandBuffer()
        {
            for (int g = 0; g < 8; g++)
            {
                if (freqBand[g] > bandBuffer[g])
                {
                    bandBuffer[g] = freqBand[g];
                    bufferDecrease[g] = 0.005f;
                }

                if (freqBand[g] < bandBuffer[g])
                {
                    bandBuffer[g] -= bufferDecrease[g];
                    bufferDecrease[g] *= 1.2f;
                }
            }
        }
        
        void MakeFrequencyBands()
        {
            int count = 0;

            for (int i = 0; i < 8; i++)
            {
                float average = 0;

                int sampleCount = (int)Mathf.Pow(2, i) * 2;
                if (i == 7) sampleCount += 2;

                for (int j = 0; j < sampleCount; j++)
                {
                    if (channel == Channel.Stereo)
                        average += (samplesLeft[count] + samplesRight[count]) * (count + 1);
                    else if (channel == Channel.Left)
                        average += samplesLeft[count] * (count + 1);
                    else if (channel == Channel.Right)
                        average += samplesRight[count] * (count + 1);

                    count++;
                }

                average /= count;
                freqBand[i] = average * 10;
            }
        }
    }
//}