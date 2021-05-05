import React from "react";
import "bootstrap/dist/css/bootstrap.css";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import TopMenu from "./components/TopMenu.js";
import Oidc from "oidc-client";
import Category from "./containers/Category";
import Product from "./containers/Product.js";
import Login from "./components/Login/Login";
import LoginCallback from "./components/Login/LoginCallBack";
import User from "./containers/User.js";
import CreateProduct from "./components/Product/create.js";
import UpdateProduct from "./components/Product/update";
import { Container, Row } from "reactstrap";
import CreateCategory from "./components/Category/create.js";
import UpdateCategory from "./components/Category/update.js";
import Logout from "./components/Logout/Logout";
import LogoutCallBack from "./components/Logout/LogoutCallBack";
import axios from "axios";
import history from './utilities/history';
require("dotenv").config();
export default function App() {
  const config = {
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
    authority: process.env.REACT_APP_SERVER,
    client_id: "react-admin",
    redirect_uri: process.env.REACT_APP_ADMIN1,
    response_type: "id_token token",
    scope: "openid profile rookieshop.api",
  };
  var userManager = new Oidc.UserManager(config);
  userManager.getUser().then((user) => {
    if (user) {
      localStorage.setItem("user", user.profile.role);
      axios.defaults.headers.common["Authorization"] =
        "Bearer " + user.access_token;
    }
  });
  var user = localStorage.getItem("user");
  console.log(user);
  if (user != "admin") {
    return (
      <Router history={history}>
        <Switch>
          <Route exact path="/">
            <Login userManager={userManager}></Login>
          </Route>
          <Route exact path="/signin-oidc" component={LoginCallback}></Route>
        </Switch>
      </Router>
    );
  }
  return (
    <Router history={history}>
      <Container fluid="md">
        <TopMenu />
        <br />
        <br />
        <br />
        <Row>
          <Switch>
            <Route exact path="/signin-oidc" component={LoginCallback}></Route>
            <Route exact path="/">
              <Product />
            </Route>
            <Route exact path="/category">
              <Category />
            </Route>
            <Route exact path="/user">
              <User />
            </Route>
            <Route exact path="/createProduct">
              <CreateProduct />
            </Route>

            <Route exact path="/createCategory">
              <CreateCategory />
            </Route>
            <Route
              exact
              path={["/updateCategory", "/updateCategory/:id"]}
              render={({ match }) => <UpdateCategory match={match} />}
            ></Route>

            <Route
              exact
              path={["/updateProduct", "/updateProduct/:id"]}
              render={({ match }) => <UpdateProduct match={match} />}
            />
            <Route exact path="/logout">
              <Logout userManager={userManager}></Logout>
            </Route>
            <Route
              exact
              path="/signout-oidc"
              component={LogoutCallBack}
            ></Route>
          </Switch>
        </Row>
      </Container>
    </Router>
  );
}
