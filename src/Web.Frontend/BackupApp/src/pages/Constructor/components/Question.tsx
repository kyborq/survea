import React, { useEffect, useState } from "react";
import { FieldValues, useFieldArray, useForm } from "react-hook-form";
import { Button } from "../../../components/Button/Button";
import { Icon } from "../../../components/Icon";
import { Input } from "../../../components/Input/Input";
import { uuid4 } from "../../../utils/uuid4";

import styles from "./Question.module.css";

type TForm = {
  question: string;
  options: string[];
};

type Props = {
  index: number;
  multiple?: boolean;
  text?: boolean;
  onSubmit?: (form: FieldValues) => void;
};

export const Question: React.FC<Props> = ({
  index,
  multiple,
  text,
  onSubmit,
}) => {
  const { control, register, handleSubmit } = useForm();
  const { fields, append } = useFieldArray({
    control,
    name: "options",
  });

  const qIcon = multiple ? "circleCheck" : "checkbox";

  const addOption = () => {
    append({ value: "" });
  };

  const honSubmit = () => {
    handleSubmit(onSubmit);
  };

  return (
    <div className={styles.Question}>
      <h3 className={styles.Index}>
        <Icon name={!text ? qIcon : "text"} fill="#000000" />
        {`Вопрос №${index}`}
      </h3>

      <input
        {...register(`question`)}
        onBlur={honSubmit}
        className={styles.Input}
      />

      <div className={styles.Answers}>
        {!text &&
          fields.map((field, index) => (
            <input
              key={field.id} // important to include key with field's id
              {...register(`options.${index}.value`)}
              onBlur={honSubmit}
              className={styles.Input}
            />
          ))}
        {text && <Input icon="text" />}
        <Button icon="addCircle" label="Добавить вариант" onClick={addOption} />
      </div>
    </div>
  );
};
