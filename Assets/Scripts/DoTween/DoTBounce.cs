using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DoTBounce : MonoBehaviour
{
	[SerializeField] private CanvasGroup canvasGroup;
	private Tween bounceTween;

	void Start()
	{
		Shake(0,1,2.0f);
	}

	public void Shake(int VectorX, int VectorY, float duration)
    {
		StartCoroutine(RunBounse(VectorX,VectorY, duration));
	}

	private void Bounce(int VectorX, int VectorY, float duration)
	{
		if (bounceTween != null)
		{
			bounceTween.Kill(false);
		}

		bounceTween = canvasGroup.transform.DOShakePosition(duration, strength: new Vector3(VectorX, VectorY, 0), vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
	}
	
	private IEnumerator RunBounse(int VectorX, int VectorY, float duration)
	{
		yield return new WaitForSeconds(0.5f);
		Bounce(VectorX, VectorY, duration);
	}
}
