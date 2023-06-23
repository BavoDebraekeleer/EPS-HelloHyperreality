using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float minIntensity = 0.0f;
    public float maxIntensity = 1.0f;
    public float minFlickerSpeed = 0.2f;
    public float maxFlickerSpeed = 0.5f;
    public float minFlickerDuration = 0.5f;
    public float maxFlickerDuration = 1.5f;
    public float minFlickerDelay = 5.0f;
    public float maxFlickerDelay = 10.0f;
    public AudioClip[] flickerSounds;
    public float soundweight = 0.9f;

    private float currentIntensity;
    private float timeElapsed;
    private bool isFlickering;
    private float flickerTimer;
    private float flickerSpeed;
    private float flickerDuration;
    private float flickerDelay;

    private Light lightComponent;
    private AudioSource audioSource;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        currentIntensity = maxIntensity;
        timeElapsed = 0.0f;
        isFlickering = false;
        flickerTimer = 0.0f;
        SetRandomFlickerSpeed();
        SetRandomFlickerDuration();
        SetRandomFlickerDelay();
    }

    private void Update()
    {
        if (!isFlickering)
        {
            flickerTimer += Time.deltaTime;
            if (flickerTimer >= flickerDelay)
            {
                isFlickering = true;
                flickerTimer = 0.0f;
            }
        }
        else
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= flickerSpeed)
            {
                currentIntensity = (currentIntensity == maxIntensity) ? minIntensity : maxIntensity;
                lightComponent.intensity = currentIntensity;
                timeElapsed = 0.0f;
                PlayFlickerSound();

            }

            flickerTimer += Time.deltaTime;
            if (flickerTimer >= flickerDuration)
            {
                isFlickering = false;
                flickerTimer = 0.0f;
                lightComponent.intensity = maxIntensity; // Ensure the light is set to the maximum intensity after flickering ends
                SetRandomFlickerSpeed();
                SetRandomFlickerDuration();
                SetRandomFlickerDelay();
            }
        }
    }

    private void SetRandomFlickerSpeed()
    {
        flickerSpeed = Random.Range(minFlickerSpeed, maxFlickerSpeed);
    }

    private void SetRandomFlickerDuration()
    {
        flickerDuration = Random.Range(minFlickerDuration, maxFlickerDuration);
    }

    private void SetRandomFlickerDelay()
    {
        flickerDelay = Random.Range(minFlickerDelay, maxFlickerDelay);
    }

    private void PlayFlickerSound()
    {
        if (flickerSounds != null && flickerSounds.Length > 0 && audioSource != null)
        {
            if (flickerSounds.Length == 1)
            {
                AudioClip selectedClip = flickerSounds[0];
                audioSource.PlayOneShot(selectedClip);
            }
            else if (flickerSounds.Length == 2)
            {
                // Generate a random value between 0 and 1
                float randomValue = Random.Range(0f, 1f);

                if (randomValue < soundweight) 
                {
                    AudioClip selectedClip = flickerSounds[0];
                    audioSource.PlayOneShot(selectedClip);
                }
                else  
                {
                    AudioClip selectedClip = flickerSounds[1];
                    audioSource.PlayOneShot(selectedClip);
                }
            }
        }
    }

}
