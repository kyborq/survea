import React from "react";
import { TIcon } from "../../icons";

import { classNames } from "../../utils/classNames";
import { Icon } from "../Icon";

import styles from "./Card.module.css";

type Props = {
  title?: string;
  icon?: TIcon;
  children?: React.ReactNode;
  className?: string;
  contentClassName?: string;
};

export const Card: React.FC<Props> = ({
  title,
  icon,
  children,
  className,
  contentClassName,
}) => {
  return (
    <div className={classNames(styles.Card, className)}>
      <div className={styles.CardHeader}>
        {!!icon && <Icon name={icon} fill="black" />}
        {!!title && <h3 className={styles.Title}>{title}</h3>}
      </div>
      <div className={contentClassName}>{children}</div>
    </div>
  );
};
