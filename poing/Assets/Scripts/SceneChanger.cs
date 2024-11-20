using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method to change the scene using build index
    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        
    }
}
