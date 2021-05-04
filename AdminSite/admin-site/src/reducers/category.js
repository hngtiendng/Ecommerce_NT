import * as category from "../contains/category";

const initialState = {
  categoryList: [],
};

export default (state = initialState, { type, payload }) => {
  switch (type) {
    case category.CATEGORY_LIST: {
      state.categoryList = payload;
      return { ...state };
    }
    case category.CREATE_CATEGORY: {
      state.categoryId = payload.data;
      console.log(payload);
      return { ...state };
    }
    case category.DELETE_CATEGORY: {
      state.categoryId = payload.data;
      console.log(payload);
      return { ...state };
    }
    default:
      return state;
  }
};
