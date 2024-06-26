using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerScore : MonoBehaviour
    {
        private static int _playerScore;

        [SerializeField] private GameObject textObj;
        private static Text _textLabel;
        private void Start()
        {
            _textLabel = textObj.GetComponent<Text>();
        }

        public static void UpdateScore(int value)
        {
            _playerScore += value;
            _textLabel.text = _playerScore.ToString();
        }

        public static int GetScore()
        {
            return _playerScore;
        }

        public static void Reset()
        {
            _playerScore = 0;
        }
    }
}
