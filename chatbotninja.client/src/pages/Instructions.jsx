
import React from 'react'
import { useEffect, useState } from 'react';
import styled from "styled-components";
import PerfectScrollbar from 'react-perfect-scrollbar'
import { Box } from '@mui/material';

//styles
import dashboard from '../assets/branding/chatbot_logo.png';
import HeaderBar from '../components/Header';



export function Instructions() {
  return (

    <Box>
     <HeaderBar
        title="Instructions"
        subtitle="Lista Instructions"
      />
  
      <div className='container '>

        
      </div>

    </Box>



  );

}
