using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionHandler : MonoBehaviour
{
    [SerializeField] private CharacterSoundSystem characterSound;
    [SerializeField] private GameObject _bubble;
    [SerializeField] private Image _emotinImage;
    [SerializeField] private List<Sprite> _happyEmotions;
    [SerializeField] private List<Sprite> _angryEmotions;

    private Coroutine _coroutine;

    public void ShowHappyEmotion()
    {
        _bubble.SetActive(true);
        characterSound.PlayEmotionSound();
        _emotinImage.sprite = _happyEmotions[Random.Range(0,_happyEmotions.Count)];
        _coroutine = StartCoroutine(OffBubble(_bubble));
    }

    public void ShowAngryEmotion()
    {
        _bubble.SetActive(true);
        characterSound.PlayEmotionSound();
        _emotinImage.sprite = _angryEmotions[Random.Range(0, _angryEmotions.Count)];
        _coroutine = StartCoroutine(OffBubble(_bubble));
    }

    private IEnumerator OffBubble(GameObject bubble)
    {
        float waitTime = 0.5f;
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        bubble.SetActive(false);
    }
}