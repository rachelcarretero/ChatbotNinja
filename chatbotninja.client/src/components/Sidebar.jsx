import styled from "styled-components"
import logo from "../assets/images/chatbot_titulo.png"
import { v } from "../styles/Variables";
import {
    AiOutlineLeft,
    AiOutlineHome,
    AiOutlineApartment,
    AiOutlineSetting,
} from "react-icons/ai";
import { MdOutlineAnalytics, MdLogout } from "react-icons/md";

import { NavLink } from "react-router-dom";
import { useContext } from "react";
import { ThemeContext } from "../App";
import { Container } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';

export function SideBar({ sidebarOpen, setSidebarOpen }) {
    const ModSidebaropen = () => {
        setSidebarOpen(!sidebarOpen);
    };
    const { setTheme, theme } = useContext(ThemeContext);
    const CambiarTheme = () => {
        setTheme((theme) => (theme === "light" ? "dark" : "light"));
    };

    return <>

        <Container >
            <button className="Sidebarbutton" onClick={ModSidebaropen}>
                <AiOutlineLeft />
            </button>
            <div className="Logocontent">
                <div className="imgcontent">
                    <img src={logo} />
                </div>
        
            </div>
            <Divider />
            {linksArray.map(({ icon, label, to }) => (
                <div className="LinkContainer" key={label}>
                    <NavLink
                        to={to}
                        className={({ isActive }) => `Links${isActive ? ` active` : ``}`}
                    >
                        <div className="Linkicon">{icon}</div>
                        {sidebarOpen && <span>{label}</span>}
                    </NavLink>
                </div>
            ))}
            <Divider />
            {secondarylinksArray.map(({ icon, label, to }) => (
                <div className="LinkContainer" key={label}>
                    <NavLink
                        to={to}
                        className={({ isActive }) => `Links${isActive ? ` active` : ``}`}
                    >
                        <div className="Linkicon">{icon}</div>
                        {sidebarOpen && <span>{label}</span>}
                    </NavLink>
                </div>
            ))}
            <Divider />
        </Container>
    </>
}

//#region Data links
const linksArray = [
    {
        label: "Home",
        icon: <AiOutlineHome />,
        to: "/",
    },
    {
        label: "Estadisticas",
        icon: <MdOutlineAnalytics />,
        to: "/estadisticas",
    },
    {
        label: "Productos",
        icon: <AiOutlineApartment />,
        to: "/productos",
    },
    {
        label: "Diagramas",
        icon: <MdOutlineAnalytics />,
        to: "/diagramas",
    },
    {
        label: "Reportes",
        icon: <MdOutlineAnalytics />,
        to: "/reportes",
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