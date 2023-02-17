import React from "react";

import { classNames } from "../../utils/classNames";

import styles from "./Card.module.css";

type Props = {
  title?: string;
  children?: React.ReactNode;
  className?: string;
  contentClassName?: string;
};

export const Card: React.FC<Props> = ({
  title,
  children,
  className,
  contentClassName,
}) => {
  return (
    <div className={classNames(styles.Card, className)}>
      {!!title && <h3 className={styles.Title}>{title}</h3>}
      <div className={contentClassName}>{children}</div>
    </div>
  );
};
