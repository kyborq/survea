import React from "react";
import { NavButton } from "./NavButton";

import styles from "./Navigation.module.css";

export const Navigation = () => {
  return (
    <div className={styles.Navigation}>
      <NavButton icon="home" label="Главная" link="/" />
      <NavButton icon="user" label="Профиль" link="/user" />
      <NavButton icon="newspaper" label="Новости" link="/feed" />
      <NavButton icon="calendar" label="Календарь" link="/calendar" />
      <NavButton icon="search" label="Поиск" link="/search" />
    </div>
  );
};
