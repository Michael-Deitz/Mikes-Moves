import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {Button, Collapse, Nav, NavLink, NavItem, Navbar, NavbarBrand, NavbarToggler,} from "reactstrap";
import { logout } from "../managers/authManager";
import MikesMovesLogo from "../resources/MikesMovesLogo.png";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
const [open, setOpen] = useState(false);

const toggleNavbar = () => setOpen(!open);

return (
    <div  className="d-flex justify-content-center ">
    <Navbar color="light" light fixed="true" expand="lg" className="shadow">   
        {loggedInUser ? (
        <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
            <Nav navbar style={{marginRight: "5rem", marginLeft: "5rem"}}>
                <NavItem>
                    <NavLink tag={RRNavLink} to="trailers" >
                        Trailers
                    </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={RRNavLink} to="items">
                        Items
                    </NavLink>
                </NavItem>
            <NavItem className="mr-auto" tag={RRNavLink} to="/">
            <img src={MikesMovesLogo} style={{width: "2.5rem", height: '2.5rem', marginRight: "5rem", marginLeft: "5rem"}}/>
            </NavItem>
                <NavItem>
                    <NavLink tag={RRNavLink} to="userprofile">
                        My Profile
                    </NavLink>
                </NavItem> 
            </Nav>
            </Collapse>
            <Button
            color="primary"
            onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                setLoggedInUser(null);
                setOpen(false);
                });
            }}
            >
            Logout
            </Button>
        </>
        ) : (
        <Nav navbar>
            <NavItem>
            <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
            </NavLink>
            </NavItem>
        </Nav>
        )}
    </Navbar>
    </div>
);
}