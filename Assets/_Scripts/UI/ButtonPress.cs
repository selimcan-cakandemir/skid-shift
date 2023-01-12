using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private int _transitionDuration;

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
    }

    public void FadeFunction()
    {
        StartCoroutine(ClickEnumarator());
    }

    public IEnumerator ClickEnumarator()
    {
        float elapsedTime = 0;
        float startValue = _fadeImage.color.a;
        while (elapsedTime < _transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, 1, elapsedTime / _transitionDuration);
            if(_fadeImage != null)
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, newAlpha);       
            yield return null;
        }
        SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
    }
   
}
