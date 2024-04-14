
import React from 'react'
import { useEffect, useState } from 'react';
import styled from "styled-components";
import PerfectScrollbar from 'react-perfect-scrollbar'
import { Box } from '@mui/material';

//styles
import dashboard from '../assets/branding/chatbot_logo.png';
import HeaderBar from '../components/Header';
import '../styles/chatbot.css';


export function Dashboard() {
  return (

    <Box>

      <HeaderBar
        title="ChatbotNinja"
        subtitle="Dashboard Page"
      />
      <Box clasName="container" >
        <img src={dashboard}  />
      </Box>

    </Box>



  );

}
const Container = styled.div`
  height:100vh;
`