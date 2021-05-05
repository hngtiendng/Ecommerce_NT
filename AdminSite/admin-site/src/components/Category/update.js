import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input, FormText } from "reactstrap";

import { useDispatch } from "react-redux";
import { update_category } from "../../actions/category";
import history from "../../utilities/history";

const UpdateCategory = ({ match }) => {
  const { id } = match.params;
  const [category, setCategory] = useState({ id: id });
  const updateCategory = async () => {
    await dispatch(update_category(category));
    history.goBack();
    console.log(category);
  };
  const dispatch = useDispatch();

  return (
    <div>
      <Form>
        <FormGroup>
          <Label for="exampleEmail">Name</Label>
          <Input
            type="text"
            name="name"
            id="exampleEmail"
            placeholder="Name"
            onChange={(e) => setCategory({ ...category, name: e.target.value })}
          />
        </FormGroup>
        <FormGroup>
          <Label for="exampleEmail">Description</Label>
          <Input
            type="text"
            name="name"
            id="exampleEmail"
            placeholder="Description"
            onChange={(e) =>
              setCategory({ ...category, description: e.target.value })
            }
          />
        </FormGroup>
      </Form>
      <Button
        color="success"
        onClick={() => {
          updateCategory();
        }}
      >
        Update
      </Button>{" "}
    </div>
  );
};

export default UpdateCategory;
