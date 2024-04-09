using UnityEngine;

namespace Assets.Scenes.Lighthouse
{
    public class Configuration : MonoBehaviour
    {
        public static Configuration Instance { get; private set; }
        public static GameObject PlayerObject { get; set; }
        public static PlayerController PlayerController { get; set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            PlayerObject = GameObject.FindGameObjectWithTag("Player");
            PlayerController = PlayerObject.GetComponent<PlayerController>();

            DontDestroyOnLoad(gameObject);
        }
    }
}