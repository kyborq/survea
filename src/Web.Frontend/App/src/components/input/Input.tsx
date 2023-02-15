import React, { forwardRef } from "react";
import { TIcon } from "../../icons";
import { Icon } from "../Icon";

import styles from "./Input.module.css";

type Props = {
  icon: TIcon;
  placeholder?: string;
  label?: string;
  name?: string;
  onChange?: React.ChangeEventHandler<HTMLInputElement>;
  onBlur?: React.FocusEventHandler<HTMLInputElement>;
};

type Ref = HTMLInputElement;

export const Input = forwardRef<Ref, Props>(
  ({ icon, label, placeholder, name, onBlur, onChange }, ref) => (
    <label className={styles.InputContainer}>
      {!!label && <span className={styles.Label}>{label}</span>}
      <div className={styles.Field}>
        <Icon name={icon} fill="#000000" />
        <input
          placeholder={placeholder}
          name={name}
          onBlur={onBlur}
          onChange={onChange}
          className={styles.Input}
          ref={ref}
        />
      </div>
    </label>
  )
);
