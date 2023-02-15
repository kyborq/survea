import React from "react";
import { NavLink } from "react-router-dom";
import { classNames } from "../../utils/classNames";
import { Icon } from "../Icon";

import styles from "./Profile.module.css";

type Props = {
  avatar?: string;
  name: string;
};

export const Profile: React.FC<Props> = ({ avatar, name }) => {
  return (
    <NavLink
      to="/profile"
      className={({ isActive }) =>
        classNames(styles.Profile, isActive && styles.Active)
      }
    >
      <div className={styles.Avatar}>
        {!!avatar ? (
          <img src={avatar} className={styles.Image} />
        ) : (
          <Icon name="user" fill="#000000" />
        )}
      </div>
      <span className={styles.Label}>{name}</span>
      <Icon name="dropRight" fill="#c7c7c7" />
    </NavLink>
  );
};
