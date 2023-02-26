import React from "react";
import {
  Control,
  FieldValues,
  useFieldArray,
  UseFormRegister,
} from "react-hook-form";
import { Button } from "../../../components/button/Button";
import { QuestionForm } from "./QuestionForm";
import { QuestionPanel } from "./QuestionPanel";

export type TQuestionsForm = {
  question: string;
  options: string[];
  type: number;
};

export type TQuestionForm = {
  name: string;
  questions: TQuestionsForm[];
};

type Props = {
  control: Control<TQuestionForm>;
  register: UseFormRegister<TQuestionForm>;
};

export const EditorForm: React.FC<Props> = ({ control, register }) => {
  const { fields, append, remove } = useFieldArray({
    control,
    name: "questions",
  });

  return (
    <div>
      <QuestionPanel
        addSingle={() => {
          append({
            question: "Вопрос 1",
            options: ["Опция 1", "Опция 2"],
            type: 0,
          });
        }}
      />
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          gap: 16,
        }}
      >
        <h1>Формочка</h1>
        {fields.map((field, index) => {
          return (
            <QuestionForm
              key={field.id}
              index={index}
              control={control}
              register={register}
            />
          );
        })}
      </div>
    </div>
  );
};
