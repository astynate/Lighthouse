using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scenes.Lighthouse.Сharacters.NPC
{
    public class NPC : MonoBehaviour
    {
        [Range(0, 10)] public float speed = 3.5f;

        [Range(0, 10)] public float minDistance = 0.5f;
        
        protected GameObject _playerObject;

        protected PlayerController _player;

        public void GetPlayer()
        {
            _playerObject = GameObject.FindWithTag("Player");
            _player = _playerObject.GetComponent<PlayerController>();
        }

        public void FollowCharacter()
        {
            if (_player.isHide == true)
            {
                return;
            }

            transform.LookAt(_playerObject.transform);

            if (Vector3.Distance(transform.position, _playerObject.transform.position) >= minDistance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
}
