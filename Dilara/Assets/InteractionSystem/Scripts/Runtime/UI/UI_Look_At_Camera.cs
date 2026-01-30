using UnityEngine;

namespace InteractionSystem.Runtime.UI
{
    /// <summary>
    /// World Space UI elemanlarının her zaman ana kameraya bakmasını sağlar 
    /// ve Canvas'ın Event Camera'sını otomatik atar.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class UI_LookAtCamera : MonoBehaviour
    {
        #region Fields

        private Canvas m_Canvas;

        #endregion

        #region Unity Methods

        private void Start()
        {
            m_Canvas = GetComponent<Canvas>();

            // Eğer Event Camera atanmamışsa ana kamerayı otomatik atar
            if (m_Canvas.worldCamera == null && Camera.main != null)
            {
                m_Canvas.worldCamera = Camera.main;
            }
        }

        private void LateUpdate()
        {
            if (Camera.main == null) return;

            // Yazının ters görünmemesi için kameranın baktığı yöne doğru hizalanmasını sağlar
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
        }

        #endregion
    }
}