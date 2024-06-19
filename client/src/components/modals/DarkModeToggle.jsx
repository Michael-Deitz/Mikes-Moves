// DarkModeToggle.js
import React from 'react';
import { Button } from 'reactstrap';

const DarkModeToggle = ({ isDarkMode, toggleDarkMode }) => {
    return (
        <Button onClick={toggleDarkMode}>
            {isDarkMode ? 'Switch to Light Mode' : 'Switch to Dark Mode'}
        </Button>
    );
};

export default DarkModeToggle;
