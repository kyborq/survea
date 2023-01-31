import React from "react";
import { NavLink } from "react-router-dom";

import { TIcon } from "../../icons";
import { classNames } from "../../utils/classnames";

import { Icon } from "../Icon";

import styles from "./NavButton.module.css";

type Props = {
  icon: TIcon;
  link: string;
  label: string;
};

export const NavButton: React.FC<Props> = ({ icon, link, label }) => {
  return (
    <NavLink
      className={({ isActive }) =>
        classNames(styles.Button, isActive && styles.Active)
      }
      to={link}
    >
      <Icon name={icon} fill="#212429" />
      <span className={styles.Label}>{label}</span>
    </NavLink>
  );
};
