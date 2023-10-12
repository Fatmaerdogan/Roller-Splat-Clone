using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Transform Ground;
    public float GroundNumber { get; set; }
    public int CurrentLevel { get; set; }
    public static GameManager instance;

    List<GameObject> GroundList=new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach (Transform child in Ground) 
        {
            GroundList.Add(child.gameObject);
        }
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        GroundNumber = GroundList.Count;
    }
   
}
