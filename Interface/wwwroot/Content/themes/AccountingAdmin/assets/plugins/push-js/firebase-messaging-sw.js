
 
var config = {
    apiKey: "AIzaSyCXTml9ZLWsNnVEyaM3aRda8oMBxxSXDjg",
    authDomain: "glassmanotification.firebaseapp.com",
    messagingSenderId: "432302208802",
};
firebase.initializeApp(config);
 
var messaging = firebase.messaging();
messaging.setBackgroundMessageHandler(function (payload) {
    var dataFromServer = JSON.parse(payload.data.notification);
    var notificationTitle = dataFromServer.title;
    var notificationOptions = {
        body: dataFromServer.body,
        icon: dataFromServer.icon,
        data: {
            url:dataFromServer.url
        }
    };
    return self.registration.showNotification(notificationTitle,
        notificationOptions);
});
 
self.addEventListener("notificationclick", function (event)
{
    var urlToRedirect = event.notification.data.url;
    event.notification.close();
    event.waitUntil(self.clients.openWindow(urlToRedirect));
});