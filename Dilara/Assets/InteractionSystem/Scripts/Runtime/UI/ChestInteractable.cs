using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Interactables
{
    public class ChestInteractable : MonoBehaviour, IInteractable
    {
        [Header("Settings")]
        [SerializeField] private float m_HoldDuration = 2.0f;
        [SerializeField] private string m_Prompt = "Hold E to Open";

        [Header("References")]
        [SerializeField] private GameObject m_InteractionUI;
        [SerializeField] private Image m_ProgressBar;
        
        [Header("Chest Components")]
        [SerializeField] private Animator m_Animator; // Assetin içindeki Animator
        [SerializeField] private GameObject m_KeyObject; // Sandık içindeki gizli anahtar

        private float m_CurrentHoldTime = 0f;
        private bool m_IsHovered = false;
        private bool m_IsOpen = false;

        public string InteractionPrompt => m_Prompt;

        public void OnHoverEnter()
        {
            if (m_IsOpen) return;
            m_IsHovered = true;
            if (m_InteractionUI != null) m_InteractionUI.SetActive(true);
        }

        public void OnHoverExit()
        {
            m_IsHovered = false;
            if (m_InteractionUI != null) m_InteractionUI.SetActive(false);
            m_CurrentHoldTime = 0f;
            if (m_ProgressBar != null) m_ProgressBar.fillAmount = 0;
        }

        public void Interact() { /* Hold mekaniği Update'de çalışıyor */ }

        private void Update()
        {
            if (m_IsOpen || !m_IsHovered) return;

            // E tuşuna basılı tutuluyor mu?
            if (Keyboard.current.eKey.isPressed)
            {
                m_CurrentHoldTime += Time.deltaTime;
                if (m_ProgressBar != null)
                    m_ProgressBar.fillAmount = m_CurrentHoldTime / m_HoldDuration;

                if (m_CurrentHoldTime >= m_HoldDuration)
                {
                    ExecuteOpen();
                }
            }
            else
            {
                // Bırakınca barı yavaşça sıfırla
                if (m_CurrentHoldTime > 0)
                {
                    m_CurrentHoldTime -= Time.deltaTime * 2;
                    if (m_ProgressBar != null) m_ProgressBar.fillAmount = m_CurrentHoldTime / m_HoldDuration;
                }
            }
        }

        private void ExecuteOpen()
        {
            m_IsOpen = true;
            if (m_InteractionUI != null) m_InteractionUI.SetActive(false);

            // Animator Tetikleme
            if (m_Animator != null)
                m_Animator.SetTrigger("Open");

            // Anahtarı Aktif Et (Sandık açılınca görünecek)
            if (m_KeyObject != null)
                m_KeyObject.SetActive(true);

            Debug.Log("Sandık açıldı!");
        }
    }
}