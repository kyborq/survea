import React from "react";
import { TIcon } from "../../icons";
import { classNames } from "../../utils/classNames";
import { Icon } from "../Icon";

import styles from "./Wrap.module.css";

type Props = {
  title?: string;
  children?: React.ReactNode;
  icon?: TIcon;
  centered?: boolean;
};

export const Wrap: React.FC<Props> = ({ children, title, icon, centered }) => {
  return (
    <div className={classNames(styles.Wrap, centered && styles.Centered)}>
      {(!!icon || !!title) && (
        <div className={styles.Header}>
          {!!icon && <Icon name={icon} fill="#000000" />}
          {!!title && <h2 className={styles.Title}>{title}</h2>}
        </div>
      )}
      {children}
    </div>
  );
};
