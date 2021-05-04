import React, { Fragment, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { get_category_list } from "../actions/category";
import CategoryList from "../components/Category";
export default function Category() {
  let dispatch = useDispatch();

  useEffect(() => {
    dispatch(get_category_list());
  }, []);
  const { categoryList } = useSelector((state) => state.category);

  var list_category = categoryList.data;

  return (
    <Fragment>
      <CategoryList list={list_category} />
    </Fragment>
  );
}
