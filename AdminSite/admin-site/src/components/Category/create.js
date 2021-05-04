import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input, FormText } from "reactstrap";
import { useDispatch } from "react-redux";
import { create_category } from "../../actions/category";

import { Link } from "react-router-dom";
const CreateCategory = () => {
  const [category, setCategory] = useState();
  const postCategory = async () => {
    dispatch(create_category(category));
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

          <FormText color="muted">
            This is some placeholder block-level help text for the above input.
            It's a bit lighter and easily wraps to a new line.
          </FormText>
        </FormGroup>
      </Form>
      {/* <Link to='/product'> </Link> */}
      <Link to="category">
        <Button
          color="success"
          onClick={() => {
            postCategory();
          }}
        >
          Create
        </Button>
      </Link>
    </div>
  );
};

export default CreateCategory;
