import { Box } from '@mui/material';
import React from 'react'
import { useEffect, useState } from 'react';
import { Container } from 'react-bootstrap';



export function Weather() {
    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);


    // cargamos la tabla 

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

            <Box>

                <h4 id="tabelLabel">Weather forecast</h4>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}

            </Box>

        </>
    );

    async function populateWeatherData() {
        const response = await fetch('/api/weatherforecast');
         const data = await response.json();
        setForecasts(data);
    }

}

