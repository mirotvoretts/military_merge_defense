mergeInto(LibraryManager.library, {
  	ShowAdv: function () {
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onClose: function(wasShown) {
				  myGameInstance.SendMessage("AdvertShower", "AdvertEnded")
				},
				onError: function(error) {
				  // some action on error
				}
			}
		})
  	},
  });