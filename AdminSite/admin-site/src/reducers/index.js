import { combineReducers } from "redux";
import product from "./product";
import category from "./category";
import user from "./user";
const rootReducer = combineReducers({
  product,
  category,
  user,
});
export default rootReducer;
