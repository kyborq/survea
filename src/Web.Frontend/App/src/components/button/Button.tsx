import React from "react";
import { TIcon } from "../../icons";
import { classNames } from "../../utils/classNames";
import { Icon } from "../Icon";

import styles from "./Button.module.css";

type Props = {
  icon?: TIcon;
  label: string;
  fill?: boolean;
  primary?: boolean;
  className?: string;
  onClick?: () => void;
};

export const Button: React.FC<Props> = ({
  label,
  icon,
  fill,
  primary,
  className,
  onClick,
}) => {
  return (
    <button
      className={classNames(
        styles.Button,
        fill && styles.Fill,
        primary && styles.Primary,
        className
      )}
      onClick={onClick}
    >
      {!!icon && <Icon name={icon} fill="black" />}
      <span className={styles.Label}>{label}</span>
    </button>
  );
};
