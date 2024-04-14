
import React from 'react'
import { useEffect, useState } from 'react';
import styled from "styled-components";
import PerfectScrollbar from 'react-perfect-scrollbar'
import { Box, Typography, useTheme } from '@mui/material';
import { DataGrid } from "@mui/x-data-grid";

//styles
import { tokens } from "../theme";
import dashboard from '../assets/branding/chatbot_logo.png';
import HeaderBar from '../components/Header';



export function PersonalitiesAndTrails() {

  const theme = useTheme();
  const colors = tokens(theme.palette.mode);

  const [personalities, setPersonalities] = useState();

  const contents = personalities === undefined
    ? <p><em>NO pilla la API. </em></p>
    : <table className="table table-striped" aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Id</th>
          <th>Nombre</th>
          <th>Descripcion</th>
          <th>Activo</th>
        </tr>
      </thead>
      <tbody>
        {personalities.map(per =>
          <tr key={per.personalityid}>
            <td>{per.personalityid}</td>
            <td>{per.name}</td>
            <td>{per.description}</td>
            <td>{per.active}</td>
          </tr>
        )}
      </tbody>
    </table>;



  useEffect(() => {
    populatePersonalities();
  }, []);

  return (

    <Box>
      <HeaderBar
        title="Personalitie And Trails"
        subtitle="Lista Personalities"
      />

      <Box
        m="40px 0 0 0"
        height="75vh"
        sx={{
          "& .MuiDataGrid-root": {
            border: "none",
          },
          "& .MuiDataGrid-cell": {
            borderBottom: "none",
          },
          "& .name-column--cell": {
            color: colors.greenAccent[300],
          },
          "& .MuiDataGrid-columnHeaders": {
            backgroundColor: colors.blueAccent[700],
            borderBottom: "none",
          },
          "& .MuiDataGrid-virtualScroller": {
            backgroundColor: colors.primary[400],
          },
          "& .MuiDataGrid-footerContainer": {
            borderTop: "none",
            backgroundColor: colors.blueAccent[700],
          },
          "& .MuiCheckbox-root": {
            color: `${colors.greenAccent[200]} !important`,
          },
        }}
      >


        {contents}

      </Box>


    </Box>



  );


  // get 
  async function populatePersonalities() {
    const response = await fetch('/api/personalities/listall');
    const data = await response.json();
    setPersonalities(data);
  }


}
