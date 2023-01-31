import React from "react";
import { Outlet } from "react-router-dom";

import { Footer } from "../components/Footer/Footer";
import { Header } from "../components/Header/Header";
import { Navigation } from "../components/Navigation/Navigation";

import styles from "./Root.module.css";

export const Root = () => {
  return (
    <div className={styles.Root}>
      <Header />
      <div className={styles.Wrap}>
        <div className={styles.Sidebar}>
          <Navigation />
        </div>
        <div className={styles.Content}>
          <Outlet />
        </div>
      </div>
      <Footer />
    </div>
  );
};
