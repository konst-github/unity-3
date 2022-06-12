using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Asteroids
{
    public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private bool isMouseOver = false;
        private bool isMouseDown = false;

        [SerializeField] private Sprite spriteMouseOver;
        [SerializeField] private Sprite spriteMouseDown;
        [SerializeField] private Sprite spriteNormal;

        [SerializeField] private Image buttonImage;

        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("OnPointerEnter");
            isMouseOver = true;
            buttonImage.sprite = isMouseDown ? spriteMouseDown : spriteMouseOver;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("OnPointerExit");
            isMouseOver = false;
            buttonImage.sprite = isMouseDown ? spriteMouseDown : spriteNormal;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //Debug.Log("OnPointerDown");
            isMouseDown = true;
            buttonImage.sprite = spriteMouseDown;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //Debug.Log("OnPointerUp");
            isMouseDown = false;
            buttonImage.sprite = isMouseOver ? spriteMouseOver : spriteNormal;
        }
    }
}