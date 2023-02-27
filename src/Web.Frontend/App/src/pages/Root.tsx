import React, { useEffect } from "react";
import { Outlet, useLocation, useNavigate } from "react-router-dom";

import { Sidebar } from "../components/sidebar/Sidebar";
import { useAppSelector } from "../store/hooks";

import styles from "./Root.module.css";

export const Root = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const path = location.pathname;

  const inAuth = path.match(/login|register/);

  const isLogged = useAppSelector((state) => state.user.logged);

  // useEffect(() => {
  //   !isLogged && navigate("/login");
  //   isLogged && inAuth && navigate("/");
  // }, []);

  return (
    <div className={styles.Root}>
      {!inAuth && <Sidebar />}
      <div className={styles.Page}>
        <Outlet />
      </div>
    </div>
  );
};
