using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{
    public Image characterImage; // Drag Image component Messi ke sini
    public List<Sprite> characterSprites; // Tambahkan semua karakter
    private int currentIndex = 0;

    void Start()
    {
        // Set sprite awal saat start
        if (characterSprites != null && characterSprites.Count > 0)
        {
            characterImage.sprite = characterSprites[currentIndex];
        }
    }

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

    // Tambahan: untuk mendapatkan karakter yang sedang dipilih
    public Sprite GetSelectedSprite()
    {
        return characterImage.sprite;
    }

    // Tambahan opsional: untuk mendapatkan nama karakter (jika kamu lebih suka pakai string)
    public string GetSelectedCharacterName()
    {
        return characterImage.sprite.name;
    }
}
