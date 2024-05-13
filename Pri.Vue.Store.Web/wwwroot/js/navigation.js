
var navbarVue = new Vue({
    el: ".navbar",
    name: "navigation",//sets the name of the vue instance
    data: {
        email: "",
        password: "",
        baseUrl: "https://localhost:7086/api/authentication/",
        isLoggedIn: false,
        isError: false,
        errorMessage: "",
    },
    created: function () {

    },
    methods: {
        submitLogin: async function () {
            //get the input data
            //validate input data
            //generate json object

            const loginDto = {
                email: this.email,
                password: this.password
            };
            //do a post
            const url = `${this.baseUrl}login`;
            await axios.post(url, loginDto)
                .then(response => {
                    console.log(response.data.bearerToken);
                })
                .catch(error => {
                    console.log(error);
                });
                //if error => showError
            //store the token
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
