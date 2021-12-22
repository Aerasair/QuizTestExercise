using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DoTFade : MonoBehaviour
{
	[SerializeField] private CanvasGroup canvasGroup;
	private Tween fadeTween;

	void Start()
	{
		StartCoroutine(RunFade());
	}

	public void FadeIn(float duration)
	{
		Fade(1f, duration, () =>
		{
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		});
	}

	public void FadeOut(float duration)
	{
		Fade(0f, duration, () =>
		{
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		});
	}

	public void FadeOutIn(float durationOut, float durationIn)
    {
		Sequence seq = DOTween.Sequence();
		seq.Append(canvasGroup.DOFade(0f, durationOut));
		seq.Append(canvasGroup.DOFade(1f, durationIn));
	}

	private void Fade(float endValue, float duration, TweenCallback onEnd)
	{
		if (fadeTween != null)
		{
			fadeTween.Kill(false);
		}

		fadeTween = canvasGroup.DOFade(endValue, duration);
	}

	private IEnumerator RunFade()
	{
		yield return new WaitForSeconds(0.5f);
		FadeIn(1f);
	}
}

