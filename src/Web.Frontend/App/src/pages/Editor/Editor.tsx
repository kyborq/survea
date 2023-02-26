import React from "react";

import { Wrap } from "../../components/wrap/Wrap";
import { QuestionPanel } from "./components/QuestionPanel";
import { QuestionForm } from "./components/QuestionForm";
import {
  Controller,
  FormProvider,
  useFieldArray,
  useForm,
} from "react-hook-form";

export const Editor = () => {
  const form = useForm({
    defaultValues: {
      questions: [
        {
          name: "",
          options: [{ value: "" }, { value: "" }],
        },
      ],
    },
  });

  const { control, register } = form;

  const { fields, remove, append } = useFieldArray({
    control,
    name: "questions",
  });

  console.log(form.getValues());

  return (
    <Wrap title="Редактор" icon="edit">
      <QuestionPanel
        addSingle={() => {
          append({
            name: "",
            options: [{ value: "" }, { value: "" }],
          });
        }}
      />

      <FormProvider {...form}>
        {fields.map((field, index) => (
          <QuestionForm index={index} />
        ))}
      </FormProvider>
    </Wrap>
  );
};
