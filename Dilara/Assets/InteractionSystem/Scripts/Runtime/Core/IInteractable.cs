namespace InteractionSystem.Runtime.Core
{
    /// <summary>
    /// Etkileşime geçilebilir nesneler için temel arayüz.
    /// </summary>
    public interface IInteractable
    {
        #region Properties

        /// <summary> Nesne üzerinde görünecek etkileşim metni. </summary>
        string InteractionPrompt { get; }

        #endregion

        #region Methods

        /// <summary> Oyuncu nesneye baktığında tetiklenir. </summary>
        void OnHoverEnter();

        /// <summary> Oyuncu nesneden gözünü çektiğinde tetiklenir. </summary>
        void OnHoverExit();

        /// <summary> Etkileşim tuşuna basıldığında tetiklenir. </summary>
        void Interact();

        #endregion
    }
}