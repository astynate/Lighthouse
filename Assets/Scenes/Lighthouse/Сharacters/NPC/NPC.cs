using UnityEngine;

namespace Assets.Scenes.Lighthouse.Сharacters.NPC
{
    public class NPC : MonoBehaviour
    {
        [Range(0, 10)] public float speed = 3.5f;

        [Range(0, 10)] public float minDistance = 1f;
        
        protected GameObject _playerObject;

        protected PlayerController _player;

        [SerializeField] private Transform[] _wayPoints;

        private int _currentPoint = 0;

        //protected bool _isFollow = false;

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

        public void Walk(bool follow)
        {
            if (follow)
            {
                FollowCharacter();
            }
            else
            {
                if (Vector3.Distance(transform.position, _wayPoints[_currentPoint].position) < 0.7f)
                {
                    _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
                }

                transform.LookAt(_wayPoints[_currentPoint].position);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
}
