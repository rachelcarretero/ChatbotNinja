import { Routes, Route } from "react-router-dom";
import { Dashboard } from "./pages/Dashboard";
import { Characters } from "./pages/Characters";
import { PersonalitiesAndTrails } from "./pages/PersonalitiesAndTrails";
import { Instructions } from "./pages/Instructions";
import { TemplateRoless } from "./pages/TemplateRoles";

import {Weather} from "./pages/wheather";

export function MyRoutes() {
  return (
   
     
      <Routes>
        <Route path="/" element={<Dashboard />} ></Route>
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/characters" element={<Characters />} />
        <Route path="/templateroles" element={<TemplateRoless />} />
        <Route path="/personalitiesandtrails" element={<PersonalitiesAndTrails />} />
        <Route path="/Instructions" element={<Instructions />} />
        <Route path="/wheather" element={<Weather />} />
      </Routes>
    
  );
}
