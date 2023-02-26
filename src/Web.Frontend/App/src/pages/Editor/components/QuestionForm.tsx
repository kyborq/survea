import React, { useEffect } from "react";
import {
  FieldValues,
  SubmitHandler,
  useFieldArray,
  useForm,
  useFormContext,
} from "react-hook-form";

import { IconButton } from "../../../components/button/IconButton";
import { Card } from "../../../components/card/Card";
import { Input } from "../../../components/input/Input";

import styles from "./QuestionForm.module.css";

type Props = {
  index?: number;
  onSubmit?: SubmitHandler<FieldValues>;
};

export const QuestionForm: React.FC<Props> = ({ index, onSubmit }) => {
  const { handleSubmit, control, register, setValue } = useFormContext();

  const { fields, remove, append } = useFieldArray({
    control,
    name: "options",
  });

  return (
    <Card>
      <form
        onSubmit={(e) => e.preventDefault()}
        onChange={handleSubmit(onSubmit)}
      >
        <Input
          icon="info"
          placeholder={`Вопрос №${index + 1}`}
          {...register("name" as const)}
        />
        <div className={styles.Options}>
          {fields.map((field, index) => (
            <Input
              key={field.id}
              icon="circleCheck"
              placeholder={`Вариант ${index + 1}`}
              {...register(`options.${index}.value` as const)}
            />
          ))}
        </div>

        <div className={styles.Footer}>
          <IconButton
            onClick={() => {
              append({ value: "" });
            }}
            icon="addCircle"
          />
          <IconButton
            icon="trash"
            onClick={() => {
              fields.length > 2 && remove(fields.length - 1);
            }}
          />
        </div>
      </form>
    </Card>
  );
};
