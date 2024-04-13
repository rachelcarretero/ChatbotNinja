import React from 'react'
import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container } from 'react-bootstrap';
import { MyRoutes } from './routes';
import { BrowserRouter } from 'react-router-dom';
import { Light, Dark } from "./styles/Themes";

import { ThemeProvider } from "styled-components";
import { SideBar } from './components/Sidebar';

import dashboard from './assets/images/chatbot_logo.png';

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
                        <Container>
                            <h5 id="tabelLabel">ChatbotNinja</h5>
                            <p>This component demonstrates fetching data from the server.</p>


                            <div className='container '>

                            <img src={dashboard} />
                            </div>
                            <SideBar
                                sidebarOpen={sidebarOpen}
                                setSidebarOpen={setSidebarOpen}
                            />


                            <MyRoutes />
                        </Container>
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