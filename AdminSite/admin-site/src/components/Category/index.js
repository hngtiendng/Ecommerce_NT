import React, { useEffect } from "react";
import { Table, Button } from "reactstrap";
import history from "../../utilities/history";
import { useDispatch } from "react-redux";
import { update_category, delete_category } from "../../actions/category";
import { Link } from "react-router-dom";
export default function CategoryList(props) {
  useEffect(() => {
    dispatch(update_category());
    //checkVar();
  }, []);

  const dispatch = useDispatch();
  const refreshPage = async (e) => {
    await dispatch(delete_category(e.id));
    await window.location.reload(false);
  };
  return (
    <div>
      <Link to="createCategory">
        <Button color="success">Create</Button>{" "}
      </Link>
      <Table class="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Option</th>
          </tr>
        </thead>
        <tbody>
          {props.list &&
            props.list.map((item) => {
              return (
                <tr>
                  <th scope="row">{item.id}</th>
                  <td>{item.name}</td>
                  <td>{item.description}</td>
                  <td>
                    <Link to={`updateCategory/${item.id}`}>
                      <Button color="info">Update</Button>{" "}
                    </Link>
                    <Button color="danger" onClick={() => refreshPage(item)}>
                      Delete
                    </Button>{" "}
                  </td>
                </tr>
              );
            })}
        </tbody>
      </Table>
    </div>
  );
}
