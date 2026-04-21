window.appAuth = {
    registerLogoutListener: function () {
        window.addEventListener('storage', function (e) {
            if (e.key === 'Agenda.Blazor.Logout') {
                window.location.replace('/Login');
            }
        });
    }
};