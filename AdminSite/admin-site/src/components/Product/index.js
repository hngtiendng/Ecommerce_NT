import React from "react";
import { Table, Button } from "reactstrap";
import { Link } from "react-router-dom";
console.log(process.env.REACT_APP_ADMIN);
export default function ProductList(props) {
  return (
    <Table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Price</th>
          <th scope="col">Image</th>
          <th scope="col">Option</th>
          <th scope="col">
            <Link to="/createProduct">
              <Button color="success">Create</Button>
            </Link>
          </th>
        </tr>
      </thead>
      <tbody>
        {props.list &&
          props.list.map((item) => {
            return (
              <tr>
                <th scope="row">{item.id}</th>
                <td>{item.name}</td>
                <td>{item.price}</td>
                <td>
                  <img
                    style={{ height: "50px" }}
                    src={`${process.env.REACT_APP_SERVER}${item.imageLocation[0]}`}
                    alt="product image"
                  />
                </td>
                <td>
                  <Link to={`updateProduct/${item.id}`}>
                    <Button color="info">Update</Button>
                  </Link>
                </td>
              </tr>
            );
          })}
      </tbody>
    </Table>
  );
}
