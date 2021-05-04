import api from "../api";
import {
  CATEGORY_LIST,
  CREATE_CATEGORY,
  UPDATE_CATEGORY,
} from "../contains/category";
export const get_category_list = () => async (dispatch) => {
  try {
    const data = await api.Category.getAllCategory();

    dispatch({
      type: CATEGORY_LIST,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
export const create_category = (category) => async (dispatch) => {
  try {
    const data = await api.Category.createCategory(category);
    dispatch({
      type: CREATE_CATEGORY,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
export const update_category = (category) => async (dispatch) => {
  try {
    const data = await api.Category.updateCategory(category);

    dispatch({
      type: UPDATE_CATEGORY,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
