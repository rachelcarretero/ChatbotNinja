import { Routes, Route } from "react-router-dom";
import { Home } from "./pages/Home";
import { Estadisticas } from "./pages/Estadisticas";
import { Productos } from "./pages/Productos";
import {Diagramas} from "./pages/Diagramas";
import {Reportes} from "./pages/Reportes";
import {Weather} from "./pages/wheather";

export function MyRoutes() {
  return (
   
     
      <Routes>
        <Route path="/" element={<Home />} >sdf</Route>
        <Route path="/productos" element={<Productos />} />
        <Route path="/estadisticas" element={<Estadisticas />} />
        <Route path="/diagramas" element={<Diagramas />} />
        <Route path="/reportes" element={<Reportes />} />
        <Route path="/wheather" element={<Weather />} />
      </Routes>
    
  );
}
