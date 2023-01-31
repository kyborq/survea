import React from "react";
import { TIcon } from "../../icons";
import { classNames } from "../../utils/classnames";
import { Icon } from "../Icon";

import styles from "./Button.module.css";

type Props = {
  icon: TIcon;
  label?: string;
  primary?: boolean;
  className?: string;
  onClick?: () => void;
};

export const Button: React.FC<Props> = ({
  icon,
  label,
  primary,
  className,
  onClick,
}) => {
  return (
    <button
      className={classNames(
        styles.Button,
        className,
        !label && styles.Compact,
        primary && styles.Primary
      )}
      onClick={onClick}
    >
      <Icon name={icon} fill={primary ? "#ffffff" : "#212429"} />
      {!!label && <span className={styles.Label}>{label}</span>}
    </button>
  );
};
