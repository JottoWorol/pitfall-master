using UnityEngine;

namespace Core.UI
{
    public class GameWindow : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(true);
            transform.SetAsLastSibling();
        }

        public void Close()
        {
            gameObject.SetActive(false);   
        }
    }
}