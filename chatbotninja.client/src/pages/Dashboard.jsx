
import React from 'react'
import { useEffect, useState } from 'react';
import styled from "styled-components";
import PerfectScrollbar from 'react-perfect-scrollbar'
import { Box } from '@mui/material';

//styles
import dashboard from '../assets/branding/chatbot_logo.png';
import HeaderBar from '../components/Header';



export function Dashboard() {
  return (

    <Box>

      <h4 id="tabelLabel">ChatbotNinja</h4>
      <p>This component demonstrates fetching data from the server.</p>

 {/* todo:ver como pasar por param 
      <HeaderBar   /> */}
      <div className='container '>

        <img src={dashboard} />
      </div>

    </Box>



  );

}
const Container = styled.div`
  height:100vh;
`