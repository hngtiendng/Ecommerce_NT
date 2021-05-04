import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
export default function TopMenu() {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

  return (
    <Navbar color="light" light expand="md" fixed="top">
      <NavbarBrand>
        <Link to="/">Product</Link>
      </NavbarBrand>
      <NavbarToggler onClick={toggle} />
      <Collapse isOpen={isOpen} navbar>
        <Nav className="mr-auto" navbar>
          <NavItem>
            <NavLink>
              <Link to="/user">View User</Link>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink>
              <Link to="/category">Manage Category</Link>
            </NavLink>
          </NavItem>
        </Nav>
        <Nav className="sm-auto" navbar>
          <NavLink>
            <Link to="/logout">Log Out</Link>
          </NavLink>
        </Nav>
      </Collapse>
    </Navbar>
  );
}
