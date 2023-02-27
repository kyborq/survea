import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import { Root } from "./pages/Root";
import { Home } from "./pages/Home/Home";
import { Editor } from "./pages/Editor/Editor";
import { Search } from "./pages/Search/Search";
import { Profile } from "./pages/Profile/Profile";
import { Login } from "./pages/Login/Login";
import { Register } from "./pages/Register/Register";
import { TestView } from "./pages/Home/TestView";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    children: [
      {
        path: "/",
        element: <Home />,
      },
      {
        path: "/test/:id",
        element: <TestView />,
      },
      {
        path: "/search",
        element: <Search />,
      },
      {
        path: "/editor",
        element: <Editor />,
      },
      {
        path: "/profile",
        element: <Profile />,
      },
      {
        path: "/login",
        element: <Login />,
      },
      {
        path: "/register",
        element: <Register />,
      },
    ],
  },
]);

export const App = () => {
  return <RouterProvider router={router} />;
};
