import axios from "axios";
require("dotenv").config();

axios.defaults.baseURL = process.env.REACT_APP_SERVER;

const Product = {
  getAllProducts: async () => await axios.get("/api/Product"),
  createProduct: async (data) => await axios.post(`api/Product`, data),
  updateProduct: async (data) => await axios.put("api/product", data),
  deleteproduct: async (id) => await axios.delete(`api/product/${id}`),
};

const Category = {
  getAllCategory: async () => await axios.get("/api/Category"),
  updateCategory: async (category) => await axios.put("api/Category", category),
  createCategory: async (data) => await axios.post(`api/Category`, data),
};

const Images = {
  postImages: async (data) => await axios.post("/api/Image", data),
};

const User = {
  getAllUser: async () => await axios.get("/api/User"),
};
export default { Product, Category, Images, User };
