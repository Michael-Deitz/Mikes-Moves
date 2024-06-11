import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getProfileWithRolesById, updateUserProfile } from "../../managers/userProfileManager";
import { Form, FormGroup, Input, Button, Spinner, ButtonGroup, ButtonToolbar } from "reactstrap";
import PageContainer from "../PageContainer";

export default function UpdateUserProfile() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [userProfile, setUserProfile] = useState(null);

  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    if (id) {
      getProfileWithRolesById(id).then((profileObj) => {
        setUserProfile(profileObj);
        setFirstName(profileObj.firstName);
        setLastName(profileObj.lastName);
        setUserName(profileObj.userName);
        setEmail(profileObj.email);
        setPhoneNumber(profileObj.phoneNumber);
      });
    }
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const userProfile = {
      id: id, 
      firstName: firstName,
      lastName: lastName,
      userName: userName,
      email: email,
      phoneNumber: phoneNumber,
    };

    updateUserProfile(userProfile.id, userProfile).then(() => {
      navigate(`/userprofile`);
    });
  };

  if (!userProfile) {
    return (
        <PageContainer>
            <Spinner/>
        </PageContainer>
    );
  };

  return (
    <PageContainer>
      <h4 className="mt-2" style={{ display: "flex", justifyContent: "center" }}>
        Edit Your Profile
      </h4>
      <Form className="w-50 m-auto" style={{ maxWidth: "20rem" }} onSubmit={handleSubmit}>
        <FormGroup>
          <Input
            type="text"
            value={firstName}
            placeholder="First Name"
            onChange={(e) => setFirstName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Input
            type="text"
            value={lastName}
            placeholder="Last Name"
            onChange={(e) => setLastName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Input
            type="text"
            value={userName}
            placeholder="User Name"
            onChange={(e) => setUserName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Input
            type="email"
            value={email}
            placeholder="Email"
            onChange={(e) => setEmail(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Input
            type="text"
            value={phoneNumber}
            placeholder="Phone Number"
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </FormGroup>
        <ButtonToolbar className="gap-2 d-flex justify-content-center" >
        <Button color="success" type="submit">Update Profile</Button>
        <Button color="danger" onClick={() => navigate(`/userprofile`)}>Cancel</Button>
        </ButtonToolbar>
      </Form>
    </PageContainer>
  );
}