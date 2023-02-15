import React from "react";

import { Logo } from "../logo/Logo";
import { Navigation } from "../Navigation";
import { Profile } from "../profile/Profile";

import styles from "./Sidebar.module.css";

export const Sidebar = () => {
  return (
    <div className={styles.Container}>
      <div className={styles.Sidebar}>
        <Logo />
        <Navigation />
        <Profile name="Костян" />
      </div>
    </div>
  );
};
