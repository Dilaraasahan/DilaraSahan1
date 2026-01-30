using UnityEngine;
using TMPro;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Interactables
{
    /// <summary>
    /// Kilit mekanizmalı ve anahtar kontrollü kapı sınıfı.
    /// </summary>
    public class DoorInteractable : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private string m_OpenPrompt = "Press E to Open";
        [SerializeField] private string m_LockedPrompt = "Find Key!";
        [SerializeField] private bool m_IsLocked = true; // Başlangıçta kilitli

        [Header("References")]
        [SerializeField] private GameObject m_InteractionUI; // Nesnenin üzerindeki Canvas
        [SerializeField] private TextMeshProUGUI m_PromptText;

        private bool m_IsOpen = false;

        #endregion

        #region Properties

        /// <summary> Kapının durumuna göre dinamik yazı döndürür. </summary>
        public string InteractionPrompt => m_IsLocked ? m_LockedPrompt : m_OpenPrompt;

        #endregion

        #region Methods

        /// <summary> Oyuncu kapıya baktığında yazıyı açar. </summary>
        public void OnHoverEnter()
        {
            if (m_InteractionUI != null)
            {
                m_PromptText.text = InteractionPrompt;
                m_InteractionUI.SetActive(true);
            }
        }

        /// <summary> Oyuncu kafasını çevirdiğinde yazıyı kapatir. </summary>
        public void OnHoverExit()
        {
            if (m_InteractionUI != null)
                m_InteractionUI.SetActive(false);
        }

        /// <summary> E tuşuna basıldığında tetiklenen ana mantık. </summary>
        public void Interact()
        {
            if (m_IsLocked)
            {
                // TODO: Envanter kontrolü buraya gelecek
                Debug.Log("Door is locked. You need a key!");
                m_PromptText.text = m_LockedPrompt;
                return;
            }

            ToggleDoor();
        }

        private void ToggleDoor()
        {
            m_IsOpen = !m_IsOpen;
            
            // Kapıyı basitçe 90 derece döndürür (Görsel temsil)
            float angle = m_IsOpen ? 90f : 0f;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            
            Debug.Log(m_IsOpen ? "Door Opened" : "Door Closed");
        }

        /// <summary> Dışarıdan anahtar ile kilidi açmak için kullanılır. </summary>
        public void Unlock()
        {
            m_IsLocked = false;
        }

        #endregion
    }
}