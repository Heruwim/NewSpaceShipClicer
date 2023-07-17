using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
    [SerializeField] private float _persentShowAds;
    [SerializeField] private Shop _shop;
    
    private PlayerInput _input;

    private void Start()
    {
        InsterstitialAds.S.LoadAd();        
        StartCoroutine(LoadInsterstitialAds());
        if(_shop != null)
            _shop.ResetWeaponsState();
    }

    public void Initialize(PlayerInput input)
    {
        _input = input;		
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        _input.Player.Shoot.Disable();
        
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        _input.Player.Shoot.Enable();

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }   

    private IEnumerator LoadInsterstitialAds()
    {
        yield return new WaitForSeconds(0.5f);
        ShowingAds();
    }
    private void ShowingAds()
    {
        float tempPersent = Random.Range(0f, 1f);

        if (tempPersent > _persentShowAds)
        {
            InsterstitialAds.S.ShowAd();
        }
    }
}
