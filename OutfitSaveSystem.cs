using UnityEngine;

public static class OutfitSaveSystem
{
    public static int savedHat, savedHair, savedShirt, savedPants, savedFace, savedShoes;

    public static void SaveOutfit(int hat, int hair, int shirt, int pants, int face, int shoes)
    {
        savedHat = hat;
        savedHair = hair;
        savedShirt = shirt;
        savedPants = pants;
        savedFace = face;
        savedShoes = shoes;
    }
}