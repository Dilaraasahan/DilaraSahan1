using UnityEngine;
using InteractionSystem.Runtime.Core; 
using InteractionSystem.Runtime.Interactables; 
using TMPro;

namespace InteractionSystem.Runtime.Interactables
{
    public class KeyInteractable : MonoBehaviour, IInteractable
    {
        [Header("Settings")]
        [SerializeField] private string m_Prompt = "Pick Up Key";

        [Header("References")]
        [SerializeField] private GameObject m_InteractionUI; 
        [SerializeField] private TextMeshProUGUI m_PromptText;

        public string InteractionPrompt => m_Prompt;

        public void OnHoverEnter()
        {
            if (m_InteractionUI != null)
            {
                m_InteractionUI.SetActive(true);
                if (m_PromptText != null) m_PromptText.text = m_Prompt;
            }
        }

        public void OnHoverExit()
        {
            if (m_InteractionUI != null)
                m_InteractionUI.SetActive(false);
        }

        public void Interact()
        {
            Debug.Log("Anahtar Alındı!");

            // 1. Sahnedeki Kapıyı Bul ve Kilidini Aç
            DoorInteractable door = Object.FindAnyObjectByType<DoorInteractable>();
            if (door != null)
            {
                door.Unlock(); // Kapının kilidini kaldırır
                Debug.Log("Kapı kilidi açıldı!");
            }
            else
            {
                Debug.LogWarning("Sahnede DoorInteractable bulunamadı!");
            }

            // 2. Anahtarı Yok Et 
            Destroy(gameObject);
        }
    }
}