namespace Data.Enums {
	public enum PopupOrder {
		/// <summary>
		/// Creates the popup and adds at the end of waiting list.
		/// Will show popup when current is closed.
		/// </summary>
		BehindOfOpenPopup,

		/// <summary>
		/// Creates the popup and adds at the beginning of waiting list.
		/// Immediately shows on top of opened popup.
		/// </summary>
		OnTopOfOpenPopup
	}
}