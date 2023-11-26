using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100 ;
    public int currentHealth ;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth ;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0)
        {
            SceneManager.LoadScene(2);
        }
         //if (Input.GetKeyDown(KeyCode.Space)){
          //  TakeDamage(2);
        // }
        
    }
    public void TakeDamage(int damage){//調用上述Takedamage(2)，把2轉接成damage變數
        currentHealth -=damage ;//currenthealth初始直=100,受到傷害-2
        healthBar.SetHealth(currentHealth);
    }
}
