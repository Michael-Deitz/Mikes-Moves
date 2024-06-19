import { useState } from "react";
import { register } from "../../managers/authManager";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, Label } from "reactstrap";
import DefaultUser from "../../resources/DefaultUser.png";

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [imageLocation, setImageLocation] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errors, setErrors] = useState([]);
  const [passwordMismatch, setPasswordMismatch] = useState(false);
  

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      const newUser = {
        firstName,
        lastName,
        userName,
        email,
        password,
        phoneNumber,
        imageLocation: imageLocation || DefaultUser, // Use default image if imageLocation is empty
      };
      register(newUser).then((response) => {
        if (response.errors) {
          const errorArray = Array.isArray(response.errors)
            ? response.errors.map((error) =>
                typeof error === "object" ? JSON.stringify(error) : error
              )
            : [
                typeof response.errors === "object"
                  ? JSON.stringify(response.errors)
                  : response.errors,
              ];
          setErrors(errorArray);
        } else {
          setLoggedInUser(response);
          navigate("/");
        }
      });
    }
  };

  return (
    <div className="container" style={{ maxWidth: "500px" }}>
      <h3>Sign Up</h3>
      <form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>First Name</Label>
          <Input
            type="text"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label>Last Name</Label>
          <Input
            type="text"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label>Email</Label>
          <Input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label>User Name</Label>
          <Input
            type="text"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label>Phone Number</Label>
          <Input
            type="tel" // Use type="tel" for phone number input
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label>Image URL</Label>
          <Input
            type="text"
            value={imageLocation}
            onChange={(e) => setImageLocation(e.target.value)}
          />
          {imageLocation && ( // Render preview if imageLocation is provided
            <img
              src={imageLocation}
              alt="User"
              style={{ width: "100px", marginTop: "10px" }}
            />
          )}
          {!imageLocation && ( // Render default image if imageLocation is empty
            <img
              src={DefaultUser}
              alt="Default"
              style={{ width: "100px", marginTop: "10px" }}
            />
          )}
        </FormGroup>
        <FormGroup>
          <Label>Password</Label>
          <Input
            invalid={passwordMismatch}
            type="password"
            value={password}
            onChange={(e) => {
              setPasswordMismatch(false);
              setPassword(e.target.value);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>Confirm Password</Label>
          <Input
            invalid={passwordMismatch}
            type="password"
            value={confirmPassword}
            onChange={(e) => {
              setPasswordMismatch(false);
              setConfirmPassword(e.target.value);
            }}
          />
          <FormFeedback>Passwords do not match!</FormFeedback>
        </FormGroup>
        {errors.length > 0 && (
          <div className="alert alert-danger">
            {errors.map((e, i) => (
              <p key={i}>{e}</p>
            ))}
          </div>
        )}
        <Button color="primary" type="submit" disabled={passwordMismatch}>
          Register
        </Button>
      </form>
      <p>
        Already signed up? Log in <Link to="/login">here</Link>
      </p>
    </div>
  );
}


