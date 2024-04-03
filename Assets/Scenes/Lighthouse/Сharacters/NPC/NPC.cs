using UnityEngine;

namespace Assets.Scenes.Lighthouse.Сharacters.NPC
{
    public class NPC : MonoBehaviour
    {
        [Range(0, 10)] public float speed = 3.5f;

        [Range(0, 10)] public float minDistance = 0.5f;
        
        protected GameObject _playerObject;

        public void GetPlayerObject()
        {
            _playerObject = GameObject.FindWithTag("Player");
        }

        public void FollowCharacter()
        {
            transform.LookAt(_playerObject.transform);

            if (Vector3.Distance(transform.position, _playerObject.transform.position) >= minDistance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
}
