using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonPress);
    }

    private void OnButtonPress()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Scenes/GameScene");
    }
}