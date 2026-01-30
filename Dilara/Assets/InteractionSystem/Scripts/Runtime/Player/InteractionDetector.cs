using UnityEngine;
using UnityEngine.InputSystem; // MUTLAKA EKLE (Yeni sistem için)
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private float m_InteractionRange = 3f;
        [SerializeField] private LayerMask m_InteractableLayer;

        private IInteractable m_CurrentInteractable;

        #endregion

        #region Unity Methods

        private void Update()
        {
            PerformRaycast();
            HandleInput();
        }

        #endregion

        #region Methods

        private void PerformRaycast()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, m_InteractionRange, m_InteractableLayer))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    if (m_CurrentInteractable != interactable)
                    {
                        m_CurrentInteractable?.OnHoverExit();
                        m_CurrentInteractable = interactable;
                        m_CurrentInteractable.OnHoverEnter();
                    }
                    return;
                }
            }

            if (m_CurrentInteractable != null)
            {
                m_CurrentInteractable.OnHoverExit();
                m_CurrentInteractable = null;
            }
        }

        /// <summary>
        /// Yeni Input System'e göre tuş kontrolü.
        /// </summary>
        private void HandleInput()
        {
            // Keyboard.current.eKey.wasPressedThisFrame ifadesi, eski sistemdeki GetKeyDown ile aynı işi yapar.
            if (m_CurrentInteractable != null && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                m_CurrentInteractable.Interact();
            }
        }

        #endregion
    }
}