import React from "react";
import { NavButton } from "./NavButton";

import styles from "./Navigation.module.css";

export const Navigation = () => {
  return (
    <div className={styles.Navigation}>
      <NavButton icon="home" label="Главная" link="/" />
      <NavButton icon="user" label="Профиль" link="/profile" />
      <NavButton icon="newspaper" label="Опросы" link="/surveys" />
    </div>
  );
};
