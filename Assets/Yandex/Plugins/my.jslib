mergeInto(LibraryManager.library, {
  	ShowAdv: function () {
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onClose: function(wasShown) {
				  myGameInstance.SendMessage("AdvertSystem", "AdvertEnded")
				},
				onError: function(error) {
				  // some action on error
				}
			}
		})
  	},
  });