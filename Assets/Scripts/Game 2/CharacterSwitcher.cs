using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{
    public Image characterImage; // Drag Image component Messi ke sini
    public List<Sprite> characterSprites; // Tambahkan semua karakter
    private int currentIndex = 0;

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characterSprites.Count;
        characterImage.sprite = characterSprites[currentIndex];
    }

    public void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + characterSprites.Count) % characterSprites.Count;
        characterImage.sprite = characterSprites[currentIndex];
    }
}
