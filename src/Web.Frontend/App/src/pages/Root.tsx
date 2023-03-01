import React, { useEffect } from "react";
import { Outlet, useLocation, useNavigate } from "react-router-dom";

import { Sidebar } from "../components/sidebar/Sidebar";
import { Configuration, UserApi } from "../services";
import { useAppSelector } from "../store/hooks";

import styles from "./Root.module.css";

export const Root = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const path = location.pathname;

  const inAuth = path.match(/login|register/);

  const isLogged = useAppSelector((state) => state.user.logged);

  useEffect(() => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const userApi = new UserApi(config);
    userApi
      .apiUserCurrentGet({
        withCredentials: true,
      })
      .catch(() => {
        navigate("/login");
      });
  }, []);

  return (
    <div className={styles.Root}>
      {!inAuth && <Sidebar />}
      <div className={styles.Page}>
        <Outlet />
      </div>
    </div>
  );
};
