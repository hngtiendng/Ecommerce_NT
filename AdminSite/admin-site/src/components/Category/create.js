import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input, FormText } from "reactstrap";
import { useDispatch } from "react-redux";
import { create_category } from "../../actions/category";
import history from "../../utilities/history";
import { Link } from "react-router-dom";
const CreateCategory = () => {
  const [category, setCategory] = useState();
  const postCategory = async () => {
    await dispatch(create_category(category));
    await history.goBack();
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
            onChange={(e) => setCategory({ ...category, description: e.target.value })}
          />

         
        </FormGroup>
      </Form>
      <Button
          color="success"
          onClick={() => {
            postCategory();
          }}
        >
          Create
        </Button>
    </div>
  );
};

export default CreateCategory;
