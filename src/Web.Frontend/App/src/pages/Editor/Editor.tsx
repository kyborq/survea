import React from "react";
import { useForm } from "react-hook-form";
import { Button } from "../../components/button/Button";

import { Wrap } from "../../components/wrap/Wrap";
import { EditorForm, TQuestionForm } from "./components/EditorForm";

export const Editor = () => {
  const { control, register, getValues } = useForm<TQuestionForm>({
    defaultValues: {
      name: "Опросник",
      questions: [
        {
          question: "Вы собака?",
          options: ["Да", "Нет", "Я кот"],
          type: 0,
        },
      ],
    },
  });

  return (
    <Wrap title="Редактор" icon="edit">
      <EditorForm control={control} register={register} />
      <Button
        label="Сохранить"
        onClick={() => {
          console.log(getValues());
        }}
      />
    </Wrap>
  );
};
