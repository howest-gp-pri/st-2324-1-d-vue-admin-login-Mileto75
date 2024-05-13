
var navbarVue = new Vue({
    el: ".navbar",
    name: "navigation",//sets the name of the vue instance
    data: {

    },
    created: function () {

    },
    methods: {
        submitLogin: async function () {

        },
        submitLogout: function () {

        },
        decodeToken: function (token) {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));
            this.tokenObject = JSON.parse(jsonPayload);
            this.profileImage = this.tokenObject["profile-image"];
        },
    }
});
