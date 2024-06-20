import { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";
import './index.css';

function App() {
  const [loggedInUser, setLoggedInUser] = useState();
  const [isDarkMode, setIsDarkMode] = useState(false);

  useEffect(() => {
    // Check local storage for the theme setting
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme === 'dark') {
      setIsDarkMode(true);
      document.body.classList.add('dark-mode');
    }

    // Get logged in user
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  const toggleDarkMode = () => {
    setIsDarkMode(!isDarkMode);
    if (!isDarkMode) {
      document.body.classList.add('dark-mode');
      localStorage.setItem('theme', 'dark');
    } else {
      document.body.classList.remove('dark-mode');
      localStorage.setItem('theme', 'light');
    }
  };

  // Wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <NavBar 
        loggedInUser={loggedInUser} 
        setLoggedInUser={setLoggedInUser} 
        isDarkMode={isDarkMode} 
        toggleDarkMode={toggleDarkMode} 
      />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
      />
    </>
  );
}

export default App;
