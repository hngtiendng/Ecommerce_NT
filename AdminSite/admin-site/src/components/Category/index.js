import React, { useEffect } from "react";
import { Table, Button } from "reactstrap";

import { useDispatch } from "react-redux";
import { update_category } from "../../actions/category";
import { Link } from "react-router-dom";
export default function CategoryList(props) {
  useEffect(() => {
    dispatch(update_category());
    //checkVar();
  }, []);

  const dispatch = useDispatch();

  return (
    <Table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
        </tr>
      </thead>
      <tbody>
        {props.list &&
          props.list.map((item) => {
            return (
              <tr>
                <th scope="row">{item.id}</th>
                <td>{item.name}</td>

                <td>
                  <Link to={`updateCategory/${item.id}`}>
                    <Button color="info">Update</Button>{" "}
                  </Link>
                </td>
              </tr>
            );
          })}
      </tbody>
    </Table>
  );
}
