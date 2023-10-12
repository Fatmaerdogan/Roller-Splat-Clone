using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image LevelSliderBar;

    void Start()
    {
        Events.LevelSliderChange += LevelSliderChange;
    }
    private void OnDestroy()
    {
        Events.LevelSliderChange -= LevelSliderChange;
    }
    void LevelSliderChange(float CurrentGroundNumber)
    {
        LevelSliderBar.fillAmount =CurrentGroundNumber / GameManager.instance.GroundNumber;
        if (LevelSliderBar.fillAmount == 1)
        {
            LevelUpdate();
        }
    }
    public void LevelUpdate()
    {
        SceneManager.LoadScene(GameManager.instance.CurrentLevel + 1);
    }
}
