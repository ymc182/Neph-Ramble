mergeInto(LibraryManager.library, {
	ConnectWallet: function () {
		try {
			window.dispatchReactUnityEvent("ConnectWallet");
		} catch (e) {
			console.warn("Failed to dispatch event");
		}
	},
	BuyAction: function () {
		try {
			window.dispatchReactUnityEvent("BuyAction");
		} catch (e) {
			console.warn("Failed to dispatch event");
		}
	},
	VoteAction: function (vote) {
		try {
			window.dispatchReactUnityEvent("VoteAction", vote);
		} catch (e) {
			console.warn("Failed to dispatch event");
		}
	},
});
