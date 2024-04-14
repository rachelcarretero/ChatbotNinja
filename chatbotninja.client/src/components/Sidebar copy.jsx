// modules 
import { MdOutlineAnalytics, MdLogout } from "react-icons/md";
import { NavLink } from "react-router-dom";
import { useContext } from "react";
import { Box } from '@mui/material';

// styles

import styled from "styled-components"
import logo from "../assets/branding/chatbot_titulo.png"
import { v } from "../styles/Variables";
import {
    AiOutlineLeft,
    AiOutlineHome,
    AiOutlineApartment,
    AiOutlineSetting,
} from "react-icons/ai";

import { ThemeContext } from "../App";
import { Container } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';

export function SideBar2({ sidebarOpen, setSidebarOpen }) {
    const ModSidebaropen = () => {
        setSidebarOpen(!sidebarOpen);
    };
    const { setTheme, theme } = useContext(ThemeContext);
    const CambiarTheme = () => {
        setTheme((theme) => (theme === "light" ? "dark" : "light"));
    };

    return <>

          
 
            <button className="layout-menu-toggle menu-link text-large ms-auto" onClick={ModSidebaropen}>
                <AiOutlineLeft />
            </button>
            <div className="app-brand demo">
                <a href="/" className="app-brand-link">
                    <span className="app-brand-logo demo">
                        <img src={logo} alt="ChatbotNinja" />
                    </span>
                </a>
            </div>

            <ul className="menu-inner py-1 ps ps--active-y">
                {linksArray.map(({ icon, label, to }) => (
                    <li className="menu-item"      key={label}>
                        <NavLink
                            to={to}
                            className={({ isActive }) => `menu-link${isActive ? ` active` : ``}`}
                        >
                            <div className="menu-icon bx bx-target-lock">{icon}</div>
                            {sidebarOpen && <span>{label}</span>}
                        </NavLink>
                    </li>
                ))}
            </ul>
            <Divider />
            <ul className="menu-inner py-1 ps ps--active-y">
            {secondarylinksArray.map(({ icon, label, to }) => (
                <div className="menu-item" key={label}>
                    <NavLink
                        to={to}
                        className={({ isActive }) => `menu-link${isActive ? ` active` : ``}`}
                    >
                        <div className="menu-icon bx bx-target-lock">{icon}</div>
                        {sidebarOpen && <span>{label}</span>}
                    </NavLink>
                </div>
            ))}
            </ul>
            
        
        
    </>
}

//#region Data links
const linksArray = [
    {
        label: "Dashboard",
        icon: <AiOutlineHome />,
        to: "/",
    },
    {
        label: "Characters",
        icon: <MdOutlineAnalytics />,
        to: "/characters",
    },
    {
        label: "Template Roles",
        icon: <AiOutlineApartment />,
        to: "/templateroles",
    },
    {
        label: "Personalities And Trails",
        icon: <MdOutlineAnalytics />,
        to: "/personalitiesandtrails",
    },
 
    {
        label: "Instructions",
        icon: <MdOutlineAnalytics />,
        to: "/instructions",
    },
    {
        label: "Weather API",
        icon: <MdOutlineAnalytics />,
        to: "/wheather",
    },
];
const secondarylinksArray = [
    {
        label: "Configuración",
        icon: <AiOutlineSetting />,
        to: "/null",
    },
    {
        label: "Salir",
        icon: <MdLogout />,
        to: "/null",
    },
];
//#endregion

const Divider = styled.div`
  height: 1px;
  width: 100%;
  background: ${(props) => props.theme.bg3};
  margin: ${v.lgSpacing} 0;
`;