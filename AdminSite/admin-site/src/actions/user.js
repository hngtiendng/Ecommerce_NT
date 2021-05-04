import api from "../api";
import { USER_LIST } from "../contains/user";
export const get_user_list = () => async (dispatch) => {
  try {
    const data = await api.User.getAllUser();

    dispatch({
      type: USER_LIST,
      payload: data,
    });
  } catch (error) {
    console.log(error);
  }
};
