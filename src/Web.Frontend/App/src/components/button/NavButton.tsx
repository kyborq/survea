import React from "react";

import { NavLink } from "react-router-dom";
import { TIcon } from "../../icons";
import { classNames } from "../../utils/classNames";
import { Icon } from "../Icon";

import styles from "./NavButton.module.css";

type Props = {
  link: string;
  icon: TIcon;
  label: string;
};

export const NavButton: React.FC<Props> = ({ icon, label, link }) => {
  return (
    <NavLink
      to={link}
      className={({ isActive }) =>
        classNames(styles.Link, isActive && styles.Active)
      }
    >
      <Icon name={icon} fill="#000000" />
      <span className={styles.Label}>{label}</span>
    </NavLink>
  );
};
