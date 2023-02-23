import React from "react";

import { NavButton } from "./button/NavButton";

export const Navigation = () => {
  return (
    <div style={{ flex: 1 }}>
      <NavButton icon="home" label="Главная" link="/" />
      <NavButton icon="search" label="Поиск" link="/search" />
      <NavButton icon="edit" label="Редактор" link="/editor" />
    </div>
  );
};
