import React from "react";
import { TIcon } from "../../icons";
import { Button } from "../Button/Button";
import { Icon } from "../Icon";

import styles from "./Input.module.css";

type Props = {
  icon: TIcon;
  placeholder?: string;
  clearButton?: boolean;
};

export const Input: React.FC<Props> = ({ icon, placeholder, clearButton }) => {
  return (
    <label className={styles.Field}>
      <Icon name={icon} fill="#c7c7c7" />
      <input placeholder={placeholder} className={styles.Input} />
      {clearButton && <Button icon="close" className={styles.ClearButton} />}
    </label>
  );
};
