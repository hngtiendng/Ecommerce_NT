import * as product from "../contains/product";

const initialState = {
  productList: [],
  product_selected: {},
  productId: 0,
};

export default (state = initialState, { type, payload }) => {
  switch (type) {
    case product.PRODUCT_LIST: {
      state.productList = payload;
      return { ...state };
    }
    case product.CREATE_PRODUCT: {
      state.productId = payload.data;
      console.log(payload);
      return { ...state };
    }
    case product.UPDATE_PRODUCT: {
      return { ...state };
    }
    default:
      return state;
  }
};
