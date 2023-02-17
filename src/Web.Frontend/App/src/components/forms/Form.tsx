import React from "react";
import { TIcon } from "../../icons";
import { Button } from "../button/Button";

import styles from "./Form.module.css";

type Props = {
  leftIcon: TIcon;
  rightIcon: TIcon;
  leftLabel: string;
  rightLabel: string;
  children?: React.ReactNode;
  leftClick?: () => void;
  rightClick?: () => void;
  onSubmit?: React.FormEventHandler<HTMLFormElement>;
};

export const Form: React.FC<Props> = ({
  children,
  leftIcon,
  leftLabel,
  rightIcon,
  rightLabel,
  leftClick,
  rightClick,
  onSubmit,
}) => {
  return (
    <form
      className={styles.Form}
      onSubmit={(e) => {
        e.preventDefault();
        onSubmit && onSubmit(e);
      }}
    >
      <div className={styles.Content}>{children}</div>
      <div className={styles.Footer}>
        <Button icon={leftIcon} label={leftLabel} onClick={leftClick} fill />
        <Button
          icon={rightIcon}
          label={rightLabel}
          onClick={rightClick}
          fill
          primary
        />
      </div>
    </form>
  );
};
