import React from "react";
import { Navbar, Nav, NavItem } from "react-bootstrap";
import '../styles/chatbot.css';
import { Typography, Box, useTheme } from "@mui/material";
import { tokens } from "../theme";


export function HeaderBar({ title, subtitle }) {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  return (

    <Box className="d-flex flex-column mt-2 mb-4">
      <Typography
        variant="h5"
        color={colors.greenAccent[400]}
        fontWeight="bold"
        sx={{ m: "0 0 5px 0" }}
      >
        {title}
      </Typography>
      <Box className="d-md-flex align-items-center justify-content-between">

        <Typography variant="p"  color={colors.grey[100]}>
          {subtitle}
        </Typography>
      </Box>
    </Box>



  );
}

export default HeaderBar;
