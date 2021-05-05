import React, { useState, useEffect } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";
import { useSelector, useDispatch } from "react-redux";
import { get_category_list } from "../../actions/category";
import {
 
  get_product_list,
  update_product,
} from "../../actions/product";
import history from "../../utilities/history";
const UpdateProduct = ({ match }) => {
  useEffect(() => {
    dispatch(get_category_list());
    dispatch(get_product_list());
    //checkVar();
  }, []);
  const { id } = match.params;
  console.log(id);
 
  const [product, setProduct] = useState({ id: id});
  const dispatch = useDispatch();

  const { categoryList } = useSelector((state) => state.category);
t);
 
  const putProduct = async () => {
    await dispatch(update_product(product));
    console.log(product);
    await history.goBack();
  };
  var list_category = categoryList.data;
  const btnClick = () => {
    return putProduct();
    //postImage()
  };

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
            onChange={(e) => setProduct({ ...product, name: e.target.value })}
          />
        </FormGroup>
        <FormGroup>
          <Label for="examplePassword">Description</Label>
          <Input
            type="text"
            name="description"
            id="examplePassword"
            placeholder="Description"
            onChange={(e) =>
              setProduct({ ...product, description: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="price">Price</Label>
          <Input
            type="text"
            name="price"
            id="price"
            placeholder="Description"
            onChange={(e) => setProduct({ ...product, price: e.target.value })}
          />
        </FormGroup>
        <FormGroup>
          <Label for="exampleSelect">Select</Label>
          <Input
            type="select"
            name="select"
            id="exampleSelect"
            defaultValue="1"
            onChange={(e) =>
              setProduct({ ...product, categoryId: e.target.value })
            }
          >
            {list_category &&
              list_category.map((e, i) => {
                return (
                  <option key={i} value={i + 1}>
                    {e.name}
                  </option>
                );
              })}
          </Input>
        </FormGroup>

      </Form>
      <Button
          color="success"
          onClick={() => {
            btnClick();
          }}
        >
          Update
        </Button>
    </div>
  );
};

export default UpdateProduct;
