import React from "react";
import { Control, useFieldArray, UseFormRegister } from "react-hook-form";

import { Button } from "../../../components/button/Button";
import { Input } from "../../../components/input/Input";
import { TQuestionForm } from "./EditorForm";

import styles from "./OptionsForm.module.css";

type Props = {
  multi?: boolean;
  index: number;
  control: Control<any>;
  register: UseFormRegister<TQuestionForm>;
};

export const OptionsForm: React.FC<Props> = ({
  control,
  multi,
  index,
  register,
}) => {
  const { fields, append, insert, remove } = useFieldArray({
    control,
    name: `questions[${index}].choices`,
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
            icon={multi ? "checkbox" : "circleCheck"}
            {...register(`questions.${index}.choices.${id}`, {
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
