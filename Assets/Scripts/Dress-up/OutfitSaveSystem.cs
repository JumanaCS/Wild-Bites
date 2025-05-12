using UnityEngine;

public static class OutfitSaveSystem
{
    public static int savedHat, savedHair, savedShirt, savedPants, savedFace, savedShoes;
    public static bool hasSavedOutfit = false;

    public static void SaveOutfit(int hat, int hair, int shirt, int pants, int face, int shoes)
    {
        savedHat = hat;
        savedHair = hair;
        savedShirt = shirt;
        savedPants = pants;
        savedFace = face;
        savedShoes = shoes;
        hasSavedOutfit = true;
        
        // Optional: Save to PlayerPrefs for persistence between game sessions
        PlayerPrefs.SetInt("savedHat", hat);
        PlayerPrefs.SetInt("savedHair", hair);
        PlayerPrefs.SetInt("savedShirt", shirt);
        PlayerPrefs.SetInt("savedPants", pants);
        PlayerPrefs.SetInt("savedFace", face);
        PlayerPrefs.SetInt("savedShoes", shoes);
        PlayerPrefs.SetInt("hasSavedOutfit", 1);
    }

    public static void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("hasSavedOutfit"))
        {
            savedHat = PlayerPrefs.GetInt("savedHat");
            savedHair = PlayerPrefs.GetInt("savedHair");
            savedShirt = PlayerPrefs.GetInt("savedShirt");
            savedPants = PlayerPrefs.GetInt("savedPants");
            savedFace = PlayerPrefs.GetInt("savedFace");
            savedShoes = PlayerPrefs.GetInt("savedShoes");
            hasSavedOutfit = true;
        }
    }
}