import React from "react";
import {
  Control,
  FieldValues,
  useFieldArray,
  UseFormRegister,
} from "react-hook-form";
import { Button } from "../../../components/button/Button";
import { Question } from "../../../services";
import { QuestionForm } from "./QuestionForm";
import { QuestionPanel } from "./QuestionPanel";

export type TQuestionsForm = {
  questionName: string;
  choices: string[];
  questionType: number;
};

export type TQuestionForm = {
  name: string;
  questions: Question[];
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
            questionName: "Одиночный выбор",
            choices: ["Опция 1", "Опция 2"],
            questionType: 0,
          });
        }}
        addMultiple={() => {
          append({
            questionName: "Мульти выбор",
            choices: ["Опция 1", "Опция 2"],
            questionType: 1,
          });
        }}
        addText={() => {
          append({
            questionName: "Текстовый вопрос",
            choices: [],
            questionType: 2,
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
              type={field.questionType}
            />
          );
        })}
      </div>
    </div>
  );
};
