using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameHoverPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image backgroundTarget;                 // Tetap digunakan untuk background biasa (gambar)
    public Sprite originalBackground;              // Gambar default
    public VideoClip previewClip;                  // Video yang akan diputar saat hover
    public VideoPlayer videoPlayer;                // Komponen pemutar video
    public RawImage videoLayer;                    // Layer video (bisa enable/disable)

    private void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoLayer.enabled = false; // Sembunyikan layer video saat awal
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (videoPlayer != null && previewClip != null)
        {
            videoPlayer.clip = previewClip;
            videoLayer.enabled = true;
            videoPlayer.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoLayer.enabled = false;
        }

        if (backgroundTarget != null && originalBackground != null)
        {
            backgroundTarget.sprite = originalBackground;
        }
    }
}
