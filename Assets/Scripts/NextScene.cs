using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public TransitionController transitionController;
    public int sceneID = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transitionController.nextSceneID = sceneID;
            transitionController.closing = true;
            //SceneManager.LoadScene(sceneID);
        }
    }
}
