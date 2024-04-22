using Assets.Scenes.Lighthouse;
using System.Collections;
using UnityEngine;

public class TelephoneScript : TriggerZone, ISounds
{
    public AudioClip callEnd, lineIsBusy, receiverCall, torsion, goWork, anythingWrong;

    public float previousTime;

    private AudioSource soundSource => GetComponent<AudioSource>();

    public void Calling()
    {
        PlaySound(receiverCall, loop: true, volume: 0.5f);
    }

    public void AnythingWrong() => StartCoroutine(PlaySoundWithDelay(anythingWrong, 0));
    public void GoWork() => StartCoroutine(PlaySoundWithDelay(goWork, delay: 3));
    public void stoppedCalling() => StartCoroutine(PlaySoundWithDelay(callEnd, volume: 3, delay: 5));

    public void PlaySound(AudioClip clip, float volume = 1, bool destroy = false, float ton1 = 0.85F, float ton2 = 1.25F, bool loop = false)
    {
        soundSource.pitch = Random.Range(ton1, ton2);
        soundSource.loop = loop;
        soundSource.PlayOneShot(clip, volume);
        previousTime = clip.length;
    }

    IEnumerator PlaySoundWithDelay(AudioClip clip, float delay = 0, float volume = 1, bool destroy = false, float ton1 = 0.85F, float ton2 = 1.25F, bool loop = false)
    {
        yield return new WaitForSeconds(delay);
        PlaySound(clip);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (Configuration.isCall)
        {
            base.OnTriggerEnter(other);
            soundSource.Stop();
            AnythingWrong();
            GoWork();
            stoppedCalling();
            Configuration.isCall = false;
        }
    }
}
