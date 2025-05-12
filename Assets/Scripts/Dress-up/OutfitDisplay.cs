using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using System.Collections.Generic; 

public class OutfitDisplay : MonoBehaviour
{
    // Character renderers
    public SpriteRenderer hatRend;
    public SpriteRenderer hairRend;
    public SpriteRenderer shirtRend;
    public SpriteRenderer pantsRend;
    public SpriteRenderer faceRend;
    public SpriteRenderer shoesRend;

    // Clothing options (must match DressUpGame.cs)
    public List<Sprite> hats;
    public List<Sprite> hairs;
    public List<Sprite> shirts;
    public List<Sprite> pants;
    public List<Sprite> faces;
    public List<Sprite> shoes;


    void Start()
    {
        // Load saved outfit
        hatRend.sprite = hats[OutfitSaveSystem.savedHat];
        hairRend.sprite = hairs[OutfitSaveSystem.savedHair];
        shirtRend.sprite = shirts[OutfitSaveSystem.savedShirt];
        pantsRend.sprite = pants[OutfitSaveSystem.savedShirt];
        faceRend.sprite = faces[OutfitSaveSystem.savedFace];
        shoesRend.sprite = shoes[OutfitSaveSystem.savedShoes];
    }
}