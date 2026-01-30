using UnityEngine;
using TMPro;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Interactables
{
    /// <summary>
    /// Kilit + anahtar kontrollü kapı etkileşimi
    /// </summary>
    public class DoorInteractable : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Prompts")]
        [SerializeField] private string m_OpenPrompt = "Press E to Open";
        [SerializeField] private string m_ClosePrompt = "Press E to Close";
        [SerializeField] private string m_LockedPrompt = "Find Key!";

        [Header("State")]
        [SerializeField] private bool m_IsLocked = true;

        [Header("UI (World Space Canvas)")]
        [SerializeField] private GameObject m_InteractionUI;
        [SerializeField] private TextMeshProUGUI m_PromptText;

        private bool m_IsOpen = false;

        #endregion


        #region Properties

        /// <summary>
        /// O an hangi yazının gösterileceğini belirler
        /// </summary>
        public string InteractionPrompt
        {
            get
            {
                if (m_IsLocked)
                    return m_LockedPrompt;

                return m_IsOpen ? m_ClosePrompt : m_OpenPrompt;
            }
        }

        #endregion


        #region Hover Events

        /// <summary>
        /// Oyuncu kapıya baktığında çağrılır
        /// </summary>
        public void OnHoverEnter()
        {
            if (m_InteractionUI == null) return;

            m_PromptText.text = InteractionPrompt;
            m_InteractionUI.SetActive(true);
        }

        /// <summary>
        /// Oyuncu bakmayı bırakınca çağrılır
        /// </summary>
        public void OnHoverExit()
        {
            if (m_InteractionUI == null) return;

            m_InteractionUI.SetActive(false);
        }

        #endregion


        #region Interaction

        /// <summary>
        /// E tuşuna basılınca çalışır
        /// </summary>
        public void Interact()
        {
            // Kilitliyse sadece mesaj göster, açma
            if (m_IsLocked)
            {
                Debug.Log("Door locked");
                return;
            }

            ToggleDoor();
        }

        private void ToggleDoor()
        {
            m_IsOpen = !m_IsOpen;

            float targetAngle = m_IsOpen ? 90f : 0f;
            transform.localRotation = Quaternion.Euler(0, targetAngle, 0);

            // 🔥 EN ÖNEMLİ SATIR
            // Etkileşimden sonra UI kaybolur
            if (m_InteractionUI != null)
                m_InteractionUI.SetActive(false);

            Debug.Log(m_IsOpen ? "Door Opened" : "Door Closed");
        }

        #endregion


        #region External

        /// <summary>
        /// Anahtar alındığında dışarıdan çağırılır
        /// </summary>
        public void Unlock()
        {
            m_IsLocked = false;
            Debug.Log("Door unlocked");
        }

        #endregion
    }
}
