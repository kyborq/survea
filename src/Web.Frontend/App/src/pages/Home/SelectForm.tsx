import React from "react";
import { Button } from "../../components/button/Button";
import { TIcon } from "../../icons";

import styles from "./TestQuestion.module.css";

type Props = {
  values: string[];
  currentValue: string;
  multiple?: boolean;
  onChange?: (value: string) => void;
};

export const SelectForm: React.FC<Props> = ({
  currentValue,
  multiple,
  values,
  onChange,
}) => {
  const defaultIcon: TIcon = multiple ? "checkbox" : "circleCheck";
  const selectedIcon: TIcon = multiple
    ? "checboxChecked"
    : "checboxCircleChecked";
  const selectedValues = multiple ? currentValue.split(",") : [currentValue];

  const handleChange = (option: string) => {
    if (!multiple && option !== currentValue) {
      onChange && onChange(option);
    }

    if (multiple) {
      if (selectedValues.includes(option)) {
        const values = selectedValues.filter((v) => v !== option);
        onChange && onChange(values.join(","));
      } else {
        const values = [option, ...selectedValues];
        onChange && onChange(values.join(","));
      }
    }
  };

  return (
    <div className={styles.Options}>
      {values.map((option) => {
        const selected = selectedValues.includes(option);
        const icon = selected ? selectedIcon : defaultIcon;

        return (
          <Button
            icon={icon}
            label={option}
            className={styles.Button}
            primary={selected}
            onClick={() => handleChange(option)}
          />
        );
      })}
    </div>
  );
};
