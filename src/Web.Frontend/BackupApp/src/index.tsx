import React, { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import { Root } from "./pages/Root";

import "./style.css";

const container = document.querySelector("#app");
const root = createRoot(container);

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
  },
]);

root.render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
);
