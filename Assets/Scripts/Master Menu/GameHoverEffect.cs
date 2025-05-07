using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GameHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(0f, 1f)]
    public float fadeAlpha = 0.3f;
    public float fadeDuration = 0.2f;

    private CanvasGroup[] allGroups;

    void Start()
    {
        // Dapatkan semua CanvasGroup di parent termasuk text dan button
        allGroups = transform.parent.GetComponentsInChildren<CanvasGroup>(includeInactive: true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (CanvasGroup cg in allGroups)
        {
            float targetAlpha = (cg.gameObject == gameObject) ? 1f : fadeAlpha;
            StartCoroutine(FadeCanvasGroup(cg, cg.alpha, targetAlpha));

            // Interactable dan raycast hanya aktif untuk yg sedang di-hover
            bool isSelf = cg.gameObject == gameObject;
            cg.interactable = isSelf;
            cg.blocksRaycasts = isSelf;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (CanvasGroup cg in allGroups)
        {
            StartCoroutine(FadeCanvasGroup(cg, cg.alpha, 1f));
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            cg.alpha = Mathf.Lerp(start, end, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        cg.alpha = end;
    }
}
