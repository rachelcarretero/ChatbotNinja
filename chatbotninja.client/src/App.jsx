import React from 'react'
import { useEffect, useState } from 'react';

// components
import { Container, Nav } from 'react-bootstrap';
import { MyRoutes } from './routes';
import { BrowserRouter } from 'react-router-dom';
import { SideBar } from './components/Sidebar';
import PerfectScrollbar from 'react-perfect-scrollbar'

// styles
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/themedefault.css';

import { Light, Dark } from "./styles/Themes";
import { ThemeProvider } from "styled-components";
import { Box } from '@mui/material';
import HeaderBar from './components/Header';
import NavbarUser from './components/NavbarUser';

export const ThemeContext = React.createContext(null);

function App() {
    const [theme, setTheme] = useState("light");
    const themeStyle = theme === "light" ? Light : Dark;

    const [sidebarOpen, setSidebarOpen] = useState(true);


    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);

    const contents = forecasts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <ThemeContext.Provider value={{ setTheme, theme }}>
                <ThemeProvider theme={themeStyle}>
                    <BrowserRouter>

                        <Box sx={{ p: 2, border: '1px solid blue' }} className='layout-menu menu-vertical menu '  >
                            <SideBar
                                sidebarOpen={sidebarOpen}
                                setSidebarOpen={setSidebarOpen}
                            />
                        </Box>
                        <Box sx={{ p: 2, border: '1px solid red' }} className='layout-page'  >
                            <NavbarUser />

                            {/* paginas */}
                            <Box className="content-wrapper">
                                <Box className="container-xxl flex-grow-1 container-p-y">

                                    <PerfectScrollbar>
                                        <MyRoutes />
                                    </PerfectScrollbar>
                                </Box>
                            </Box>

                        </Box>

                    </BrowserRouter>
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