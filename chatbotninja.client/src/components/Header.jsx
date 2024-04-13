import React from "react";
import { Navbar, Nav, NavItem } from "react-bootstrap";
import '../styles/themedefault.css';
import { Box } from '@mui/material';
export function HeaderBar({ titulo }) {

    return (

      <Box className="d-flex flex-column mt-2 mb-4">
        <h3 className="h4">{titulo}</h3>
        <Box className="d-md-flex align-items-center justify-content-between">
          <p className="m-0"> Esta es la página deshboard </p>

          <a href="/Clientes/Create" className="btn btn-primary mt-2">
            <i className="bx bx-user-plus me-2"></i>  New client
          </a>
        </Box>
      </Box>

      

    );
  }
 
export default HeaderBar;
  