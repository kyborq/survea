import React from "react";
import { Control, useFieldArray, UseFormRegister } from "react-hook-form";

import { Button } from "../../../components/button/Button";
import { Input } from "../../../components/input/Input";
import { TQuestionForm } from "./EditorForm";

import styles from "./OptionsForm.module.css";

type Props = {
  index: number;
  control: Control<any>;
  register: UseFormRegister<TQuestionForm>;
};

export const OptionsForm: React.FC<Props> = ({ control, index, register }) => {
  const { fields, append, insert, remove } = useFieldArray({
    control,
    name: `questions[${index}].options`,
    rules: {
      required: true,
    },
  });

  return (
    <div className={styles.Options}>
      {fields.map((field, id) => {
        return (
          <Input
            key={field.id}
            icon="circleCheck"
            {...register(`questions.${index}.options.${id}`, {
              required: true,
            })}
            onBlur={(e) => {
              !e.target.value && remove(id);
            }}
          />
        );
      })}
      <div
        style={{
          flex: 1,
          display: "flex",
        }}
      >
        <Button
          label="Добавить"
          icon="addCircle"
          className={styles.Button}
          onClick={() => {
            append("");
          }}
        />
      </div>
    </div>
  );
};
