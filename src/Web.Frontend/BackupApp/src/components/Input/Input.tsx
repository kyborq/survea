import React, { useEffect, useState } from "react";
import { TIcon } from "../../icons";
import { classNames } from "../../utils/classnames";
import { Button } from "../Button/Button";
import { Icon } from "../Icon";

import styles from "./Input.module.css";

type Props = {
  icon: TIcon;
  placeholder?: string;
  clearButton?: boolean;
  className?: string;
  label?: string;
  initValue?: string;
  onChangeText?: (value: string) => void;
};

export const Input: React.FC<Props> = ({
  icon,
  placeholder,
  clearButton,
  className,
  initValue,
  onChangeText,
}) => {
  const [value, setValue] = useState(initValue);

  useEffect(() => {
    setValue(initValue);
  }, [initValue]);

  // useEffect(() => {
  //   onChangeText && onChangeText(value);
  // }, [value]);

  return (
    <label className={classNames(styles.Field, className)}>
      <Icon name={icon} fill="#c7c7c7" />
      <input
        value={value}
        onChange={(e) => setValue(e.target.value)}
        onBlur={() => onChangeText && onChangeText(value)}
        placeholder={placeholder}
        className={styles.Input}
      />
      {clearButton && <Button icon="close" className={styles.ClearButton} />}
    </label>
  );
};
