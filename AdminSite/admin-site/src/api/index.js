import axios from "axios";
require("dotenv").config();

axios.defaults.baseURL = process.env.REACT_APP_SERVER;

const Product = {
  getAllProducts: async () => await axios.get("/api/Product"),
  createProduct: async (data) => await axios.post(`api/Product`, data),
  updateProduct: async (data) => await axios.put("api/Product/updateProduct/", data),
  deleteProduct: async (id) => await axios.put(`api/Product/${id}`),
  getProduct: async (id) => await axios.get(`api/Product/${id}`),
};

const Category = {
  getAllCategory: async () => await axios.get("/api/Category"),
  updateCategory: async (category) => await axios.put("api/Category", category),
  createCategory: async (data) => await axios.post(`api/Category`, data),
  deleteCategory: async (id) => await axios.put(`api/Category/${id}`),
};

const Images = {
  postImages: async (data) => await axios.post("/api/Image", data),
};

const User = {
  getAllUser: async () => await axios.get("/api/User"),
};
export default { Product, Category, Images, User };
