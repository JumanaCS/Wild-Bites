using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DressUpGame : MonoBehaviour
{
    // ALL CLOTHING OPTIONS (Assign in Inspector)
    public List<Sprite> hats;
    public List<Sprite> hairs;
    public List<Sprite> shirts;
    public List<Sprite> pants;
    public List<Sprite> faces;
    public List<Sprite> shoes;

    // CHARACTER RENDERERS (Drag from Hierarchy)
    public SpriteRenderer hatRend;
    public SpriteRenderer hairRend;
    public SpriteRenderer shirtRend;
    public SpriteRenderer pantsRend;
    public SpriteRenderer faceRend;
    public SpriteRenderer shoesRend;

    // BUTTONS (Drag from Hierarchy)
    public Button hairBtn;
    public Button shirtBtn;
    public Button pantsBtn;
    public Button hatBtn;
    public Button faceBtn;
    public Button shoesBtn;
    public Button doneBtn;

    // Current selections
    private int currentHat, currentHair, currentShirt, currentPants, currentFace, currentShoes;
    private string activeCategory = "hair";

    void Start()
    {
        // Load saved outfit if it exists
        if (OutfitSaveSystem.hasSavedOutfit)
        {
            currentHat = OutfitSaveSystem.savedHat;
            currentHair = OutfitSaveSystem.savedHair;
            currentShirt = OutfitSaveSystem.savedShirt;
            currentPants = OutfitSaveSystem.savedPants;
            currentFace = OutfitSaveSystem.savedFace;
            currentShoes = OutfitSaveSystem.savedShoes;
        }

        // BUTTON CLICK LISTENERS
        hairBtn.onClick.AddListener(() => SetActiveCategory("hair"));
        shirtBtn.onClick.AddListener(() => SetActiveCategory("shirt"));
        pantsBtn.onClick.AddListener(() => SetActiveCategory("pants"));
        hatBtn.onClick.AddListener(() => SetActiveCategory("hat"));
        faceBtn.onClick.AddListener(() => SetActiveCategory("face"));
        shoesBtn.onClick.AddListener(() => SetActiveCategory("shoes"));
        doneBtn.onClick.AddListener(OnDoneClicked);

        UpdateAllClothes();
    }

    // [Rest of your existing methods remain exactly the same...]
    public void ChangeItem(int direction) 
    {
        switch(activeCategory)
        {
            case "hat": currentHat = (currentHat + direction + hats.Count) % hats.Count; break;
            case "hair": currentHair = (currentHair + direction + hairs.Count) % hairs.Count; break;
            case "shirt": currentShirt = (currentShirt + direction + shirts.Count) % shirts.Count; break;
            case "pants": currentPants = (currentPants + direction + pants.Count) % pants.Count; break;
            case "face": currentFace = (currentFace + direction + faces.Count) % faces.Count; break;
            case "shoes": currentShoes = (currentShoes + direction + shoes.Count) % shoes.Count; break;
        }
        UpdateClothes();
    }

    private void SetActiveCategory(string category)
    {
        activeCategory = category;
        ResetButtonColors();
        GetActiveButton().image.color = Color.yellow;
    }

    private Button GetActiveButton()
    {
        return activeCategory == "hair" ? hairBtn :
               activeCategory == "shirt" ? shirtBtn :
               activeCategory == "pants" ? pantsBtn :
               activeCategory == "hat" ? hatBtn :
               activeCategory == "face" ? faceBtn : shoesBtn;
    }

    private void ResetButtonColors()
    {
        hairBtn.image.color = Color.white;
        shirtBtn.image.color = Color.white;
        pantsBtn.image.color = Color.white;
        hatBtn.image.color = Color.white;
        faceBtn.image.color = Color.white;
        shoesBtn.image.color = Color.white;
    }

    private void UpdateClothes()
    {
        if (hats.Count > 0) hatRend.sprite = hats[currentHat];
        if (hairs.Count > 0) hairRend.sprite = hairs[currentHair];
        if (shirts.Count > 0) shirtRend.sprite = shirts[currentShirt];
        if (pants.Count > 0) pantsRend.sprite = pants[currentPants];
        if (faces.Count > 0) faceRend.sprite = faces[currentFace];
        if (shoes.Count > 0) shoesRend.sprite = shoes[currentShoes];
    }

    private void UpdateAllClothes()
    {
        UpdateClothes();
    }

    public void OnDoneClicked()
    {
        OutfitSaveSystem.SaveOutfit(currentHat, currentHair, currentShirt, currentPants, currentFace, currentShoes);
        SceneManager.LoadScene("Intro Crawfish");
    }
}