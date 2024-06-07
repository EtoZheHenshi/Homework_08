using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterBody : MonoBehaviour
    {
        [SerializeField] private GameObject head;
        [SerializeField] private GameObject body;
        [SerializeField] private GameObject leftHand;
        [SerializeField] private GameObject rightHand;
        [SerializeField] private GameObject leftLeg;
        [SerializeField] private GameObject rightLeg;
        public GameObject Head { get { return head; } }
        public GameObject Body { get { return body; } }
        public GameObject LeftHand { get { return leftHand; } }
        public GameObject RightHand { get { return rightHand; } }
        public GameObject LeftLeg { get { return leftLeg; } }
        public GameObject RightLeg { get { return rightLeg; } }
    }
}
