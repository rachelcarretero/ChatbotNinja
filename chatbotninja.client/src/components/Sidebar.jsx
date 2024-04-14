import MenuOutlinedIcon from "@mui/icons-material/MenuOutlined";
import { Box, IconButton, Typography, useTheme } from "@mui/material";
import { useState } from "react";
import { Menu, MenuItem, ProSidebar } from "react-pro-sidebar";
import "react-pro-sidebar/dist/css/styles.css";
import { Link } from "react-router-dom";
import { tokens } from "../theme";
import { NavLink } from "react-router-dom";
import logo from "../assets/branding/chatbot_titulo.png"
import user from "../assets/images/usericon.png"
import "../styles/chatbot.css"
// TODO CHECK ICONS !
import {
    AiOutlineLeft,
    AiOutlineHome,
    AiOutlineApartment,
    AiOutlineSetting,
} from "react-icons/ai";
import { MdOutlineAnalytics, MdLogout } from "react-icons/md";


const Item = ({ title, to, icon, selected, setSelected }) => {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    return (
        <MenuItem
            active={selected === title}
            style={{
                color: colors.grey[100],
            }}
            onClick={() => setSelected(title)}
            icon={icon}
        >
            <Typography>{title}</Typography>
            <Link to={to} />
        </MenuItem>
    );
};


export function SideBar() {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const [isCollapsed, setIsCollapsed] = useState(false);
    const [selected, setSelected] = useState("Dashboard");

    return (
        <Box
            sx={{
                "& .pro-sidebar-inner": {
                    background: `#fff !important`,
                },
                "& .pro-icon-wrapper": {
                    backgroundColor: "transparent !important",
                },
                "& .pro-inner-item": {
                    padding: "5px 35px 5px 20px !important",
                },
                "& .pro-inner-item:hover": {
                    color: "#868dfb !important",
                },
                "& .pro-menu-item.active": {
                    color: "#6870fa !important",
                } 
              
            }}
        >
            <ProSidebar collapsed={isCollapsed}>

                <Menu iconShape="square">
                    {/* LOGO AND MENU ICON */}
                    <MenuItem
                        onClick={() => setIsCollapsed(!isCollapsed)}
                        icon={isCollapsed ? <MenuOutlinedIcon /> : undefined}
                        style={{
                            margin: "10px 0 20px 0",
                            color: colors.grey[100],
                        }}
                    >
                        {!isCollapsed && (
                            <Box
                                display="flex"
                                justifyContent="space-between"
                                alignItems="center"
                                ml="15px"
                            >
                                <Box className="app-brand demo">
                                    <span className="app-brand-logo demo">
                                        <img src={logo} alt="ChatbotNinja" />
                                    </span>
                                </Box>


                                <IconButton onClick={() => setIsCollapsed(!isCollapsed)}>
                                    <MenuOutlinedIcon />
                                </IconButton>
                            </Box>
                        )}
                    </MenuItem>

                    {!isCollapsed && (
                        <Box mb="25px">
                            <Box display="flex" justifyContent="center" alignItems="center">
                                <img src={user} alt="user" width="50px" height="50px" style={{ cursor: "pointer", borderRadius: "50%" }} />
                            </Box>
                            <Box textAlign="center">
                                <Typography
                                    variant="h6"
                                    color={colors.grey[100]}
                                    fontWeight="bold"
                                    sx={{ m: "10px 0 0 0" }}
                                >
                                    Rachel
                                </Typography>
                            </Box>
                        </Box>
                    )}


                </Menu>

                {/* ITEMS */}
                <Box paddingLeft={isCollapsed ? undefined : "10%"}>

                    {linksArray.map(({ icon, label, to }) => (
                        <li className="menu-item" key={label}>
                            <NavLink
                                to={to}
                                className={({ isActive }) => `menu-link${isActive ? ` active` : ``}`}
                            >
                                <div className="menu-icon bx bx-target-lock">{icon}</div>
                                {!isCollapsed && <span>{label}</span>}
                            </NavLink>
                        </li>
                    ))}
                </Box>



            </ProSidebar>
        </Box>
    );
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

