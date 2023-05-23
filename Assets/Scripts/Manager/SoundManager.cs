using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance;
    // ���ڲ�������
    private AudioSource audioSource;
    // 
    private Dictionary<string, AudioClip> dictAudio;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        dictAudio = new Dictionary<string, AudioClip>();
    }

    // ���������� ������Ƶ����Ҫȷ����Ƶ�ļ���·����Resources�ļ�����
    public AudioClip LoadAudio(string path)
    {
        return (AudioClip)Resources.Load(path);
    }

    // ������������ȡ��Ƶ�����ҽ��仺����dictAudio�У������ظ�����
    private AudioClip GetAudio(string path)
    {
        if (!dictAudio.ContainsKey(path))
        {
            dictAudio[path] = LoadAudio(path);
        }
        return dictAudio[path];
    }

    public void PlayBGM(string name, float volume = 1.0f)
    {
        audioSource.Stop();
        audioSource.clip = GetAudio(name);
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    // ������Ч
    public void PlaySound(string path, float volume = 1f)
    {
        // PlayOneShot���Ե��Ӳ���
        this.audioSource.PlayOneShot(GetAudio(path), volume);
        // this.audioSource.volume = volume;
    }

    public void PlaySound(AudioSource audioSource, string path, float volume = 1f)
    {
        audioSource.PlayOneShot(GetAudio(path), volume);
        // audioSource.volume = volume;
    }
}