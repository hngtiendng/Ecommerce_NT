import React, { Fragment, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { get_product_list } from "../actions/product";
import ProductList from "../components/Product";
export default function Product() {
  let dispatch = useDispatch();

  useEffect(() => {
    dispatch(get_product_list());
  }, []);
  const { productList } = useSelector((state) => state.product);

  var list_product = productList.data;

  return (
    <Fragment>
      <ProductList list={list_product} />
    </Fragment>
  );
}
