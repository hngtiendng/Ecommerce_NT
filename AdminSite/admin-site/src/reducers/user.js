import * as user from "../contains/user";

const initialState = {
  userList: [],
};

export default (state = initialState, { type, payload }) => {
  switch (type) {
    case user.USER_LIST: {
      state.userList = payload;
      return { ...state };
    }

    default:
      return state;
  }
};
