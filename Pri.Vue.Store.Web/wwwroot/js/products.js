let app = new Vue({
    el: "#app",
    name: "products",
    data: {
        showCategoriesSection: false,
        showProductsSection: false,
        showProductDetailSection: false,
        showErrorSection: false,
        baseUrl: "https://localhost:7086/api/",
        categories: null,
        products: null,
        categorySearch: "",
        productSearch: "",
        productDetail: null,
        errorMessage: "",
        isLoading: false
    },
    methods: {
        showProductsFromCategory: async function (categoryId) {
            this.isLoading = true;
            await axios.get(`${this.baseUrl}categories/${categoryId}/products`)
                .then((response) => {
                    this.products = response.data;
                    this.showCategoriesSection = false;
                    this.showProductsSection = true;
                    this.showProductDetailSection = false;
                })
                .catch((e) => {
                    this.showErrorSection = true;
                    this.errorMessage = e.message
                })
                .finally(() => {
                    this.isLoading = false;
                });
        },
        showProductDetails: async function (product) {
            this.isLoading = true;
            await axios.get(`${this.baseUrl}products/${product.id}`)
                .then((response) => {
                    this.productDetail = response.data;
                    this.showCategoriesSection = false;
                    this.showProductsSection = false;
                    this.showProductDetailSection = true;
                })
                .catch((e) => {
                    this.showErrorSection = true;
                    this.errorMessage = e.message
                })
                .finally(() => {
                    this.isLoading = false;
                });
        },
        searchCategory: async function () {
            await axios.get(`${this.baseUrl}categories?search=${this.categorySearch}`)
                .then((response) => {
                    this.categories = response.data
                })
                .catch((e) => {
                    this.showErrorSection = true;
                    this.errorMessage = e.message
                });
        },
        searchProduct: async function () {
            const productsFromApi = await axios.get(`${this.baseUrl}products?search=${this.productSearch}`)
                .then((response) => {
                    this.products = response.data
                })
                .catch((e) => {
                    this.showErrorSection = true;
                    this.errorMessage = e.message
                });
        },
        showCategories: async function () {
            await axios.get(`${this.baseUrl}categories`)
                .then((response) => {
                    this.categories = response.data
                })
                .catch((e) => {
                    this.showErrorSection = true;
                    this.errorMessage = e.message
                })
                .finally(() => {
                    this.isLoading = false;
                });
            this.showCategoriesSection = true;
            this.showProductsSection = false;
            this.showProductDetailSection = false;
        },
        showProducts: async function () {
            await axios.get(`${this.baseUrl}products`)
                .then((response) => {
                    this.products = response.data
                })
                .catch((e) => {
                    this.showErrorSection = true;
                    this.errorMessage = e.message
                })
                .finally(() => {
                    this.isLoading = false;
                });
            this.showCategoriesSection = false;
            this.showProductsSection = true;
            this.showProductDetailSection = false;
        },
    }
});
