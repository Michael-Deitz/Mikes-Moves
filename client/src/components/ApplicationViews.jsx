import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserProfileDetails from "./userprofiles/MyUserProfile";
import UpdateUserProfile from "./userprofiles/UpdateUserProfile";
import TrailerList from "./trailers/TrailerList";
import ItemList from "./items/ItemList";
import TrailerDetails from "./trailers/TrailerDetails";
import ItemDetails from "./items/ItemDetails";
import CreateTrailer from "./trailers/TrailerCreate";
import CreateItem from "./items/ItemCreate";
import HomePage from "./Homepage";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route>
        <Route
          path="/"
          element={
            <AuthorizedRoute  loggedInUser={loggedInUser}>
              <HomePage/>
            </AuthorizedRoute>
          }
        />
        <Route 
          path="trailers"
        >
          <Route
            index
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <TrailerList loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <TrailerDetails loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <CreateTrailer loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id/edit"
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <CreateTrailer loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route 
          path="items"
        >
          <Route
            index
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <ItemList loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <ItemDetails loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <CreateItem loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id/edit"
            element={
              <AuthorizedRoute  loggedInUser={loggedInUser}>
                <CreateItem loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
        </Route>
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
