import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getProfileWithRolesById, } from "../../managers/userProfileManager";
import { Button, Card, CardBody, CardText, Label } from "reactstrap";

export default function UserProfileDetails({ loggedInUser }) {
  const [userProfile, setUserProfile] = useState(null);

  const navigate = useNavigate()
  
  useEffect(() => {
    getProfileWithRolesById(loggedInUser.id).then(setUserProfile);
  }, [loggedInUser]);

 

  

  return (
    <>
    <Card className="w-50 m-auto mt-3 shadow">
      <CardText className="fs-3 m-auto fw-bold">
          {userProfile?.userName}
        </CardText>
        <div className="d-flex flex-row-reverse me-2">
          <div className="d-flex">
            <Label className="me-1 fw-bold" >User Since:</Label>
            <CardText className="fst-italic">
              {userProfile?.formattedDateCreated}
            </CardText>
          </div>
        </div>
      <div className="ms-1" >
        <img alt="user profile image" className="w-25 m-auto d-flex"
          src={userProfile?.imageBlob ? `data:image/jpeg;base64,${userProfile?.imageBlob}` : (userProfile?.imageLocation)} style={{ borderRadius: "50%" }}
        />
      </div>
      <CardBody className="m-auto ">
        <Label className="fw-bold fs-4">FullName:</Label>
          <CardText className="fs-4  ">
            {userProfile?.fullName}
          </CardText>
        <Label className="fw-bold fs-4">Email:</Label>
          <CardText className="fs-4">
            {userProfile?.email}
          </CardText>
        <Label className="fw-bold fs-4">PhoneNumber:</Label>
          <CardText>
            {userProfile?.phoneNumber}
          </CardText>
      </CardBody>
    </Card>
    <div className="d-flex justify-content-center mt-4 w-">
    <Button color="primary" style={{float: "center", width:"100px"}} onClick={() => navigate(`/userprofile/${loggedInUser.id}/update`)}>Edit</Button>
    </div>
    </>
  );
}