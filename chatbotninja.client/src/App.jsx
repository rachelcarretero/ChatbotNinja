import React, { useState } from 'react';

// components
import PerfectScrollbar from 'react-perfect-scrollbar';
import { SideBar } from './components/Sidebar';
import { MyRoutes } from './routes';

// styles
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/themedefault.css';

import { Box, CssBaseline } from '@mui/material';
import { ThemeProvider } from "styled-components";
import Footer from './components/Footer';
import NavbarUser from './components/NavbarUser';
import { Dark, Light } from "./styles/Themes";
import Topbar from './components/Topbar';

export const ThemeContext = React.createContext(null);

function App() {
    const [theme, setTheme] = useState("light");
    const themeStyle = theme === "light" ? Light : Dark;

    const [sidebarOpen, setSidebarOpen] = useState(true);
    const [isSidebar, setIsSidebar] = useState(true);


    return (
        <>
            <ThemeContext.Provider value={{ setTheme, theme }}>
                <ThemeProvider theme={themeStyle}>
                    <CssBaseline />

                    <div className="app"  >
                
                        <SideBar
                         isSidebar={isSidebar} 
                        />

                        <main className="content">
                            <Box sx={{ p: 2 }}>
                                <Topbar />
                            </Box>
                            <Box  className="container-xxl flex-grow-1 container-p-y">

                                     <MyRoutes />
{/*  
                                <PerfectScrollbar>
                                    <MyRoutes />
                                </PerfectScrollbar> */}
                            </Box>
                        </main>
                    </div>

                    <Footer />

                </ThemeProvider>
            </ThemeContext.Provider>
        </>
    );

    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }
}

export default App;