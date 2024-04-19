using UnityEngine;

public interface ISounds
{
    void PlaySound(AudioClip clip, float volume = 1f, bool destroy = false, float ton1 = 0.85f, float ton2 = 1.2f, bool loop = false);
}
