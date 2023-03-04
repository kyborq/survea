import React, { useEffect, useState } from "react";
import { UserDto } from "../services";
import { getCurrentUser } from "../userUtils";

import { NavButton } from "./button/NavButton";

export const Navigation = () => {
  const [user, setUser] = useState<UserDto>(null);

  useEffect(() => {
    getCurrentUser().then((result) => setUser(result));
  }, []);

  return (
    <div style={{ flex: 1 }}>
      <NavButton icon="home" label="Главная" link="/" />
      {/* <NavButton icon="search" label="Поиск" link="/search" /> */}
      {user && user?.accountMode !== 1 && (
        <NavButton icon="edit" label="Редактор" link="/editor" />
      )}
    </div>
  );
};
