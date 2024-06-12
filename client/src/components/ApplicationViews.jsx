import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserProfileDetails from "./userprofiles/MyUserProfile";
import UpdateUserProfile from "./userprofiles/UpdateUserProfile";
import TrailerList from "./trailers/TrailerList";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route>
        <Route
          path="home"
          element={
            <AuthorizedRoute  loggedInUser={loggedInUser}>
              <></>
            </AuthorizedRoute>
          }
        />
        <Route
          path="trailers"
          element={
            <AuthorizedRoute  loggedInUser={loggedInUser}>
              <TrailerList/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="items"
          element={
            <AuthorizedRoute  loggedInUser={loggedInUser}>
              <></>
            </AuthorizedRoute>
          }
        />
        <Route
          path="userprofile"
          element={
            <AuthorizedRoute  loggedInUser={loggedInUser}>
              <UserProfileDetails loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="userprofile/:id/update"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <UpdateUserProfile loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
