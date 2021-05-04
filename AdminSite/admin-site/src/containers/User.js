import React, { Fragment, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { get_user_list } from "../actions/user";
import UserList from "../components/User";
export default function User() {
  let dispatch = useDispatch();

  useEffect(() => {
    dispatch(get_user_list());
  }, []);
  const { userList } = useSelector((state) => state.user);

  var list_user = userList.data;

  console.log(list_user);

  return (
    <Fragment>
      <UserList list={list_user} />
    </Fragment>
  );
}
