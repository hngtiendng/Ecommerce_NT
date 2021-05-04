import api from "../api";

import {
  CREATE_PRODUCT,
  PRODUCT_LIST,
  UPDATE_PRODUCT,
  DELETE_PRODUCT
} from "../contains/product";
export const get_product_list = () => async (dispatch) => {
  try {
    const data = await api.Product.getAllProducts();

    dispatch({
      type: PRODUCT_LIST,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
export const create_product = (product) => async (dispatch) => {
  try {
    const data = await api.Product.createProduct(product);
    dispatch({
      type: CREATE_PRODUCT,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
export const update_product = (product) => async (dispatch) => {
  try {
    const data = await api.Product.updateProduct(product);

    dispatch({
      type: UPDATE_PRODUCT,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
export const delete_product = (product) => async (dispatch) => {
  try {
    const data = await api.Product.deleteProduct(product);
    dispatch({
      type: DELETE_PRODUCT,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
