using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GoalUI;

    public void CompleteLevel()
    {
        GoalUI.SetActive(true);
    }
}
