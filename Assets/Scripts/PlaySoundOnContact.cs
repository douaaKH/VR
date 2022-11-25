using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnContact : MonoBehaviour
{
    public bool useVelocity = true;
    public float minVelocity = 0;
    public float maxVelocity = 2;

    public bool randomizePitch = true;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        // todo: change from name
        if(other.name == "basketball")
        {
            VelocityEstimator estimator = other.GetComponent<VelocityEstimator>();
            AudioSource source = other.GetComponent<AudioSource>();
            if (estimator && useVelocity)
            {
                float v = estimator.GetVelocityEstimate().magnitude;
                float volume = Mathf.InverseLerp(minVelocity, maxVelocity, v);

                if (randomizePitch)
                    source.pitch = Random.Range(minPitch, maxPitch);

                source.PlayOneShot(source.clip, volume);

            }
            else
            {
                if (randomizePitch)
                    source.pitch = Random.Range(minPitch, maxPitch);

                source.PlayOneShot(source.clip);
            }
        }

    }
}
