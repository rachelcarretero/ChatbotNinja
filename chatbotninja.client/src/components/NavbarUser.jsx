import React from "react";
import { Navbar, Nav, NavItem } from "react-bootstrap";
import '../styles/themedefault.css';

class NavbarUser extends React.Component {
  render() {
    return (

      <Navbar
        fixed="top"
        expand="lg"
        className="layout-navbar container-xxl navbar navbar-expand-xl navbar-detached align-items-center bg-navbar-theme"
      >
        <div className="navbar-nav-right d-flex align-items-center">
          <div className="navbar-nav-right d-flex align-items-center"></div>
          <ul className="navbar-nav flex-row align-items-center ms-auto">
            <NavItem className="nav-item font-weight-semibold d-none  d-md-flex"> hola </NavItem>
            <NavItem className="nav-item font-weight-semibold d-none  d-md-flex"> hola </NavItem>

          </ul>
        </div>

      </Navbar >

    );
  }
}

export default NavbarUser;
