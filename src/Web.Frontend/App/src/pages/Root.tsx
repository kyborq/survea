import React from "react";
import { Outlet, useLocation } from "react-router-dom";

import { Sidebar } from "../components/sidebar/Sidebar";

import styles from "./Root.module.css";

export const Root = () => {
  const location = useLocation();
  const path = location.pathname;

  const inAuth = path.match(/login|register/);

  return (
    <div className={styles.Root}>
      {!inAuth && <Sidebar />}
      <div className={styles.Page}>
        <Outlet />
      </div>
    </div>
  );
};
