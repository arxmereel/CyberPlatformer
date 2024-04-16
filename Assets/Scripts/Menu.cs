    using UnityEngine;
    using UnityEngine.SceneManagement;
     
    public class Menu : MonoBehaviour
    {
        public void swapscene(string scenename)
        {
            SceneManager.LoadScene(scenename);
        }
    }
