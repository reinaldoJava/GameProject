using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerControl : MonoBehaviour
{

    public static GameManagerControl gameManagerControl;
    private int lifes = 5;
    private int beef = 0;
    private void Awake()
    {
        if (gameManagerControl == null)
        {
            gameManagerControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        UpdateHub();

    }
    public int GetLifes()
    {
        return lifes;
    }
    public void SetLifes(int life)
    {
        lifes += life;
        if(lifes>=0)
        UpdateHub();
    }
    // Update is called once per frame
    public void SetBeef(int beef)
    {
        this.beef += beef;
        if (beef >= 5)
        {
            this.beef = 0;
            this.lifes += 1;
       
        }
        UpdateHub();
    }
    void Update()
    {

    }
    public void UpdateHub()
    {
        GameObject.Find("LifesText").GetComponent<Text>().text = lifes.ToString();
        GameObject.Find("BeefText").GetComponent<Text>().text = beef.ToString();
    }
   
}

