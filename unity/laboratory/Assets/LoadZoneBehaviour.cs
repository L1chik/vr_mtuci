using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LoadZoneBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private GameObject cube;

    private Material dissolveMat;
    
    private void Start()
    {
        dissolveMat = cube.GetComponent<Renderer>().material;
        dissolveMat.SetFloat("_CutoffHeight", -1.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        StartCoroutine(StartZone());
        GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator StartZone()
    {
        var i = 0;
        foreach (var audioClip in audioClips)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            if (i == 1)
            {
                StartCoroutine(EnableDissolve());
            }
            yield return new WaitUntil(() => !audioSource.isPlaying);
            i++;
        }
    }

    private IEnumerator EnableDissolve()
    {
        var tween = dissolveMat.DOFloat(1, "_CutoffHeight", 7f);
        tween.onComplete = () => Destroy(cube);
        yield break;
    }
}
