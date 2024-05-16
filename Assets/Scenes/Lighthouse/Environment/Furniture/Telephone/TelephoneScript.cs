using Assets.Scenes.Lighthouse;
using System.Collections;
using UnityEngine;

public class TelephoneScript : TriggerZone, ISounds
{
    public AudioClip callEnd, lineIsBusy, receiverCall, torsion, goWork, anythingWrong;

    public float previousTime;

    public string[] frases = new string[]
    {
        "���, ������ ��� ��� ����?",
        "������ ����������, ��� ������� �����",
        "�� ������ ��� ���������",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
    };

    private AudioSource soundSource => GetComponent<AudioSource>();

    private NightReport nightReport;

    private void Start()
    {
        nightReport = GetComponent<NightReport>();
    }



    ///<summary>
    ///����� ������ ����� ������
    ///</summary>
    public void Calling()
    {
        PlaySound(receiverCall, loop: true, volume: 1f);
    }

    ///<summary>
    ///����� ������ ����� "���-�� ���������"
    ///</summary>
    public void AnythingWrong() => StartCoroutine(PlaySoundWithDelay(anythingWrong, 0));

    ///<summary>
    ///����� ������ ����� "��� �������"
    ///</summary>
    public void GoWork() => StartCoroutine(PlaySoundWithDelay(goWork, delay: 3));

    ///<summary>
    ///����� ������ ����� ���������� ������
    ///</summary>
    public void stoppedCalling() => StartCoroutine(PlaySoundWithDelay(callEnd, volume: 3, delay: 5));


    ///<summary>
    ///���������������� ����� �� ���������� ISound ��� ������������ ������ ����� 
    ///</summary>
    public void PlaySound(AudioClip clip, float volume = 1, bool destroy = false, float ton1 = 0.85F, float ton2 = 1.25F, bool loop = false)
    {
        soundSource.pitch = Random.Range(ton1, ton2);
        if (loop)
        {
            soundSource.loop = true;
            soundSource.clip = clip;
            soundSource.Play();
        }
        else
        {
            soundSource.loop = false;
            soundSource.PlayOneShot(clip, volume);
        }

        previousTime = clip.length;
    }

    IEnumerator PlaySoundWithDelay(AudioClip clip, float delay = 0, float volume = 1, bool destroy = false, float ton1 = 0.85F, float ton2 = 1.25F, bool loop = false)
    {
        yield return new WaitForSeconds(delay);
        PlaySound(clip);
    }



    ///<summary>
    ///���������������� ����� �� � 
    ///</summary>
    public override void OnTriggerEnter(Collider other)
    {
        if (Configuration.isCall)
        {
            nightReport.ShowNightReport();
            base.OnTriggerEnter(other);
            soundSource.Stop();
            AnythingWrong();
            GoWork();
            stoppedCalling();
            Configuration.isCall = false;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        nightReport.HideNightReport();
    }



    public override void Interact()
    {
        Debug.Log("Phone");
    }

    ///<summary>
    ///������� ��� ������� ���������� ������
    ///delegate for the call completion event
    ///</summary>
    public delegate void CallDelegate();


    ///<summary>
    ///������� ��� ���������� ������
    ///events to end a call
    ///</summary>
    public static event CallDelegate CallIsEnd; 
}