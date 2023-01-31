import React, { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { Provider } from "react-redux";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { Constructor } from "./pages/Constructor/Constructor";
import { Home } from "./pages/Home/Home";
import { Profile } from "./pages/Profile/Profile";

import { Root } from "./pages/Root";
import { Surveys } from "./pages/Surveys/Surveys";
import { store } from "./store/store";

import "./style.css";

const container = document.querySelector("#app");
const root = createRoot(container);

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
        path: "/profile",
        element: <Profile />,
      },
      {
        path: "/surveys",
        element: <Surveys />,
      },
      {
        path: "/constructor",
        element: <Constructor />,
      },
    ],
  },
]);

root.render(
  <StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </StrictMode>
);
