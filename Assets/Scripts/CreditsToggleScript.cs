using UnityEngine.UI;
using UnityEngine;

public class CreditsToggleScript : MonoBehaviour
{
    public Text creditsText;
    private bool visible = false;

    void Awake(){
        creditsText = GameObject.Find("CredText").GetComponent<Text>();
        creditsText.gameObject.SetActive(false);
    }

    public void ToggleCredits(){
        if(visible){
            visible = false;
            creditsText.gameObject.SetActive(false);
        }else{
            visible = true;
            creditsText.gameObject.SetActive(true);
        }
    }
}
